using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NominaXpertCore.Controller;
using NominaXpertCore.Business;
using NominaXpertCore.Model;
using ControlEscolar.Utilities;
using NLog;
using NominaXpertCore.Utilities;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.Layout.Properties;
using iText.Kernel.Exceptions;
using iText.IO.Font.Constants;

namespace NominaXpert.View.UC_NominasAPI
{
    public partial class UC_NominaReciboExterno : UserControl
    {
        public int IdNomina { get; set; }
        private static readonly Logger _logger = LoggingManager.GetLogger("NominaXpert.Controller.NominaExterna");
        private readonly NominaExController _nominaExController = new NominaExController();
        private readonly BonificacionController _bonificacionController;
        private readonly NominasController _nominaController;
        private readonly DeduccionController _deduccionController;
        public UC_NominaReciboExterno(int idNomina)
        {
            InitializeComponent();
            PoblaCombo();

            _nominaController = new NominasController();
            _bonificacionController = new BonificacionController();
            _deduccionController = new DeduccionController();

            this.IdNomina = idNomina;

            if (idNomina > 0)
                CargarRecibo();
            else
                MessageBox.Show("No se proporcionó una nómina válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void PoblaCombo()
        {
            var metodosPago = new Dictionary<int, string>
    {
        { 1, "Transferencia" },
        { 2, "Efectivo" },
        { 3, "Cheque" }
    };

            cboMetodoPago.DataSource = new BindingSource(metodosPago, null);
            cboMetodoPago.DisplayMember = "Value";
            cboMetodoPago.ValueMember = "Key";
            cboMetodoPago.SelectedIndex = 0; // Por defecto Transferencia
        }


        private void CargarRecibo()
        {
            try
            {
                var tabla = _nominaExController.ObtenerNominasExternas();
                var fila = tabla.Select($"id = {IdNomina}").FirstOrDefault();
                if (fila == null)
                {
                    MessageBox.Show("No se encontró la nómina externa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblNombreEmpleado.Text = fila["nombre_empleado"].ToString();
                lblDepartamento.Text = fila["departamento"].ToString();
                lblIdEmpleado.Text = fila["id_empleado"].ToString();
                lblEstado.Text = fila["estado_pago"].ToString();

                DateTime fechaInicio = Convert.ToDateTime(fila["fecha_inicio"]);
                DateTime fechaFin = Convert.ToDateTime(fila["fecha_fin"]);
                lblFechaInicio.Text = fechaInicio.ToShortDateString();
                lblFechaFin.Text = fechaFin.ToShortDateString();

                int diasTrabajados = Convert.ToInt32(fila["dias_trabajados"]);
                decimal sueldoBase = Convert.ToDecimal(fila["salario"]);
                decimal sueldoPorDia = sueldoBase / 22m;

                if (diasTrabajados <= 0)
                {
                    int diasLaborables = diasTrabajados;
                    diasTrabajados = diasLaborables > 0 ? diasLaborables : 1;
                    _logger.Warn($"No se encontraron horas trabajadas. Se asignan {diasTrabajados * 8} horas por {diasLaborables} días laborables.");
                }

                decimal sueldoPorDiasTrabajados = sueldoPorDia * diasTrabajados;
                var percepciones = _bonificacionController.ObtenerBonificacionesPorNomina(IdNomina);
                var deducciones = _deduccionController.ObtenerDeduccionesPorNomina(IdNomina);
                decimal totalPercepciones = percepciones.Sum(p => p.Monto);
                decimal totalDeducciones = deducciones.Sum(d => d.Monto);
                decimal totalNeto = sueldoPorDiasTrabajados + totalPercepciones - totalDeducciones;

                lblTotalPercepciones.Text = totalPercepciones.ToString("C");
                lblTotalDeducciones.Text = totalDeducciones.ToString("C");
                lblSueldoBase.Text = sueldoBase.ToString("C");
                lblSueldoPorHorasTrabajadas.Text = sueldoPorDiasTrabajados.ToString("C");
                lblTotalNeto.Text = totalNeto.ToString("C");
                lblMontoLetras.Text = NominaNegocio.ConvertirNumeroALetras(totalNeto);

                if (fila["estado_pago"].ToString() == "Pagado")
                {
                    btnGenerarNómina.Visible = false;
                    btnRegresar.Visible = false;
                    lblMetodoPago.Visible = false;
                    cboMetodoPago.Visible = false;
                }
                else
                {
                    btnGenerarNómina.Enabled = true;
                    btnRegresar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al cargar el recibo de nómina externa");
                MessageBox.Show($"Error al cargar el recibo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UC_NominaReciboExterno_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerarNómina_Click(object sender, EventArgs e)
        {
            try
            {
                PagoController _pagoController = new PagoController();
                if (_pagoController.ExistePago(this.IdNomina))
                {
                    MessageBox.Show("Esta nómina ya fue pagada. No es posible generar otro pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cboMetodoPago.SelectedItem == null || string.IsNullOrWhiteSpace(cboMetodoPago.Text))
                {
                    MessageBox.Show("Debe seleccionar un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nomina = _nominaController.BuscarNominaPorId(IdNomina);
                decimal sueldoBase = nomina.SueldoBase;

                if (_nominaController.VerificarSueldoMenorMinimo(sueldoBase))
                {
                    decimal minimo = _nominaController.ObtenerSueldoMinimo();
                    MessageBox.Show($"El sueldo base del empleado (${sueldoBase:N2}) es menor al mínimo (${minimo:N2}).", "Error - Sueldo Mínimo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_nominaController.VerificarSueldoIgualMinimo(sueldoBase))
                {
                    decimal minimo = _nominaController.ObtenerSueldoMinimo();
                    DialogResult dr = MessageBox.Show($"El sueldo base del empleado (${sueldoBase:N2}) es igual al mínimo (${minimo:N2}).\n\n¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.No) return;
                }
                var tabla = _nominaExController.ObtenerNominasExternas();
                var fila = tabla.Select($"id = {IdNomina}").FirstOrDefault();

                decimal sueldoPorDia = sueldoBase / 22m;
                int diasTrabajados = Convert.ToInt32(fila["dias_trabajados"]);
                decimal sueldoPorDias = sueldoPorDia * diasTrabajados;
                var percepciones = _bonificacionController.ObtenerBonificacionesPorNomina(IdNomina);
                var deducciones = _deduccionController.ObtenerDeduccionesPorNomina(IdNomina);
                decimal totalPercepciones = percepciones.Sum(p => p.Monto);
                decimal totalDeducciones = deducciones.Sum(d => d.Monto);
                decimal totalNeto = sueldoPorDias + totalPercepciones - totalDeducciones;

                Pago nuevoPago = new Pago
                {
                    IdNomina = this.IdNomina,
                    FechaPago = DateTime.Now,
                    MontoTotal = totalNeto,
                    MontoLetras = NominaNegocio.ConvertirNumeroALetras(totalNeto),
                    MetodoPago = cboMetodoPago.Text,
                    Referencia = "Pago automático generado desde recibo de nómina"
                };

                bool exito = _pagoController.RegistrarPago(nuevoPago);

                if (exito)
                {
                    _nominaExController.ActualizarEstadoPago(this.IdNomina, "Pagado", UsuarioSesion.UsuarioId);
                    CargarRecibo();
                    MessageBox.Show("El pago ha sido registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al generar la nómina");
                MessageBox.Show($"Error al generar la nómina: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPDFReciboNomina_Click(object sender, EventArgs e)
        {
            PdfWriter writer = null;
            PdfDocument pdf = null;
            Document document = null;

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    Title = "Guardar Recibo de Nómina Externa",
                    FileName = $"ReciboNominaExterna_{IdNomina}_{DateTime.Now:yyyyMMdd}.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;

                    // Validar que el directorio exista
                    string directory = Path.GetDirectoryName(path);
                    if (!Directory.Exists(directory))
                    {
                        MessageBox.Show("El directorio seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validar que tengamos permisos de escritura
                    try
                    {
                        using (FileStream fs = File.Create(path, 1, FileOptions.DeleteOnClose))
                        {
                            // Si llegamos aquí, tenemos permisos de escritura
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se tiene permiso para escribir en la ubicación seleccionada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    writer = new PdfWriter(path);
                    pdf = new PdfDocument(writer);
                    document = new Document(pdf);

                    // Configurar fuentes
                    PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    // Encabezado
                    Paragraph header = new Paragraph("NominaXpert")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFont(boldFont)
                        .SetFontSize(24)
                        .SetMarginTop(20);

                    Paragraph subHeader = new Paragraph("Recibo de Nómina Externa")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFont(boldFont)
                        .SetFontSize(18)
                        .SetMarginBottom(20);

                    document.Add(header);
                    document.Add(subHeader);

                    // Tabla principal
                    Table mainTable = new Table(2).UseAllAvailableWidth();
                    mainTable.SetMarginTop(20);
                    mainTable.SetMarginBottom(20);

                    // Información del empleado
                    AddTableHeader(mainTable, "Datos del Empleado", boldFont);
                    AddTableRow(mainTable, "Nombre:", lblNombreEmpleado.Text ?? "", regularFont);
                    AddTableRow(mainTable, "Departamento:", lblDepartamento.Text ?? "", regularFont);
                    AddTableRow(mainTable, "ID Empleado:", lblIdEmpleado.Text ?? "", regularFont);

                    // Información de la nómina
                    AddTableHeader(mainTable, "Datos de la Nómina", boldFont);
                    AddTableRow(mainTable, "Fecha Inicio:", lblFechaInicio.Text ?? "", regularFont);
                    AddTableRow(mainTable, "Fecha Fin:", lblFechaFin.Text ?? "", regularFont);
                    AddTableRow(mainTable, "Estado:", lblEstado.Text ?? "", regularFont);

                    // Información de percepciones
                    AddTableHeader(mainTable, "Percepciones", boldFont);
                    AddTableRow(mainTable, "Sueldo Base:", lblSueldoBase.Text ?? "", regularFont);
                    AddTableRow(mainTable, "Sueldo por Horas:", lblSueldoPorHorasTrabajadas.Text ?? "", regularFont);
                    AddTableRow(mainTable, "Total Percepciones:", lblTotalPercepciones.Text ?? "", regularFont);

                    // Información de deducciones
                    AddTableHeader(mainTable, "Deducciones", boldFont);
                    AddTableRow(mainTable, "Total Deducciones:", lblTotalDeducciones.Text ?? "", regularFont);

                    // Información del total
                    AddTableHeader(mainTable, "Total Neto", boldFont);
                    AddTableRow(mainTable, "Monto Total:", lblTotalNeto.Text ?? "", regularFont);
                    AddTableRow(mainTable, "Monto en Letras:", lblMontoLetras.Text ?? "", regularFont);

                    // Agregar la tabla al documento
                    document.Add(mainTable);

                    // Pie de página
                    Paragraph footer = new Paragraph($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFont(regularFont)
                        .SetFontSize(10)
                        .SetMarginTop(20);

                    document.Add(footer);

                    // Cerrar el documento
                    document.Close();
                    document = null;
                    pdf.Close();
                    pdf = null;
                    writer.Close();
                    writer = null;

                    MessageBox.Show("El recibo de nómina externa ha sido generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al generar el PDF del recibo de nómina externa");
                MessageBox.Show($"Error al generar el PDF: {ex.Message}\n\nDetalles técnicos: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Asegurar que todos los recursos se liberen correctamente
                if (document != null)
                {
                    try { document.Close(); } catch { }
                }
                if (pdf != null)
                {
                    try { pdf.Close(); } catch { }
                }
                if (writer != null)
                {
                    try { writer.Close(); } catch { }
                }
            }
        }

        private void AddTableHeader(Table table, string text, PdfFont font)
        {
            try
            {
                Cell cell = new Cell(1, 2)
                    .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY)
                    .SetFont(font)
                    .SetPadding(5)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(text ?? ""));
                table.AddCell(cell);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al agregar encabezado de tabla: {text}");
                throw;
            }
        }

        private void AddTableRow(Table table, string label, string value, PdfFont font)
        {
            try
            {
                Cell labelCell = new Cell()
                    .SetFont(font)
                    .SetPadding(5)
                    .Add(new Paragraph(label ?? ""));
                
                Cell valueCell = new Cell()
                    .SetFont(font)
                    .SetPadding(5)
                    .Add(new Paragraph(value ?? ""));
                
                table.AddCell(labelCell);
                table.AddCell(valueCell);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al agregar fila de tabla: {label} - {value}");
                throw;
            }
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            Form mensajeForm = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new System.Drawing.Size(350, 220),
                Text = "Información del sistema",
                ControlBox = false
            };

            Label lblMensaje = new Label
            {
                Text = "Regresando a Deducciones Externas...",
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            mensajeForm.Controls.Add(lblMensaje);
            mensajeForm.Show();

            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += (s, ev) =>
            {
                timer.Stop();
                mensajeForm.Invoke((MethodInvoker)delegate { mensajeForm.Close(); });
                this.Invoke((MethodInvoker)delegate
                {
                    Control parent = this.Parent;
                    if (parent != null)
                    {
                        parent.Controls.Remove(this);
                        UC_DeduccionesExternas ucVolver = new UC_DeduccionesExternas(this.IdNomina);
                        ucVolver.Dock = DockStyle.Fill;
                        parent.Controls.Add(ucVolver);
                        parent.Controls.SetChildIndex(ucVolver, 0);
                    }
                });
            };
            timer.Start();
        }
    }
}
