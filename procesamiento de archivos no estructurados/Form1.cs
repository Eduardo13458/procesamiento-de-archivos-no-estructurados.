using System.Text;
using System.Text.RegularExpressions;

namespace procesamiento_de_archivos_no_estructurados_
{
    public partial class Form1 : Form
    {
        private string? logFilePath;
        private string? srtFilePath;
        private string[]? logLines;
        private string[]? srtLines;

        public Form1()
        {
            InitializeComponent();
        }

        #region Procesamiento de Archivos .LOG

        private void btnLoadLog_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos LOG (*.log)|*.log|Todos los archivos (*.*)|*.*",
                Title = "Seleccionar archivo LOG"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    logFilePath = openFileDialog.FileName;
                    logLines = File.ReadAllLines(logFilePath);
                    txtLogResults.Text = string.Join(Environment.NewLine, logLines);
                    MessageBox.Show($"Archivo cargado exitosamente.\nLíneas totales: {logLines.Length}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el archivo: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAnalyzeLog_Click(object sender, EventArgs e)
        {
            if (logLines == null || logLines.Length == 0)
            {
                MessageBox.Show("Primero debe cargar un archivo LOG.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var analysis = AnalyzeLogFile(logLines);
                StringBuilder result = new StringBuilder();
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine("    ANÁLISIS DE ARCHIVO LOG");
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine();
                result.AppendLine($"📄 Archivo: {Path.GetFileName(logFilePath)}");
                result.AppendLine($"📏 Total de líneas: {analysis.TotalLines}");
                result.AppendLine($"📝 Líneas con contenido: {analysis.NonEmptyLines}");
                result.AppendLine($"⚪ Líneas vacías: {analysis.EmptyLines}");
                result.AppendLine();
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine("    ESTADÍSTICAS POR NIVEL");
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine($"🔴 ERROR:   {analysis.ErrorCount} ocurrencias");
                result.AppendLine($"🟡 WARNING: {analysis.WarningCount} ocurrencias");
                result.AppendLine($"🟢 INFO:    {analysis.InfoCount} ocurrencias");
                result.AppendLine($"🔵 DEBUG:   {analysis.DebugCount} ocurrencias");
                result.AppendLine();
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine("    CONTENIDO DEL ARCHIVO");
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine();
                result.Append(string.Join(Environment.NewLine, logLines));

                txtLogResults.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al analizar el archivo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchLog_Click(object sender, EventArgs e)
        {
            if (logLines == null || logLines.Length == 0)
            {
                MessageBox.Show("Primero debe cargar un archivo LOG.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchTerm = txtSearchLog.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Ingrese un término de búsqueda.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var matchingLines = SearchInLog(logLines, searchTerm);
                StringBuilder result = new StringBuilder();
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine($"    BÚSQUEDA: '{searchTerm}'");
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine($"🔍 Coincidencias encontradas: {matchingLines.Count}");
                result.AppendLine();

                if (matchingLines.Count > 0)
                {
                    result.AppendLine("═══════════════════════════════════════");
                    result.AppendLine("    LÍNEAS ENCONTRADAS");
                    result.AppendLine("═══════════════════════════════════════");
                    result.AppendLine();

                    foreach (var match in matchingLines)
                    {
                        result.AppendLine($"Línea {match.LineNumber}: {match.Content}");
                        result.AppendLine();
                    }
                }
                else
                {
                    result.AppendLine("No se encontraron coincidencias.");
                }

                txtLogResults.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private LogAnalysis AnalyzeLogFile(string[] lines)
        {
            var analysis = new LogAnalysis
            {
                TotalLines = lines.Length,
                EmptyLines = lines.Count(string.IsNullOrWhiteSpace),
                NonEmptyLines = lines.Count(l => !string.IsNullOrWhiteSpace(l))
            };

            foreach (var line in lines)
            {
                string upperLine = line.ToUpper();
                if (upperLine.Contains("ERROR")) analysis.ErrorCount++;
                if (upperLine.Contains("WARNING") || upperLine.Contains("WARN")) analysis.WarningCount++;
                if (upperLine.Contains("INFO")) analysis.InfoCount++;
                if (upperLine.Contains("DEBUG")) analysis.DebugCount++;
            }

            return analysis;
        }

        private List<LogMatch> SearchInLog(string[] lines, string searchTerm)
        {
            var matches = new List<LogMatch>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    matches.Add(new LogMatch
                    {
                        LineNumber = i + 1,
                        Content = lines[i]
                    });
                }
            }
            return matches;
        }

        #endregion

        #region Procesamiento de Archivos .SRT

        private void btnLoadSrt_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos SRT (*.srt)|*.srt|Todos los archivos (*.*)|*.*",
                Title = "Seleccionar archivo SRT"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    srtFilePath = openFileDialog.FileName;
                    srtLines = File.ReadAllLines(srtFilePath);
                    txtSrtResults.Text = string.Join(Environment.NewLine, srtLines);
                    MessageBox.Show($"Archivo cargado exitosamente.\nLíneas totales: {srtLines.Length}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el archivo: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAnalyzeSrt_Click(object sender, EventArgs e)
        {
            if (srtLines == null || srtLines.Length == 0)
            {
                MessageBox.Show("Primero debe cargar un archivo SRT.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var analysis = AnalyzeSrtFile(srtLines);
                StringBuilder result = new StringBuilder();
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine("    ANÁLISIS DE ARCHIVO SRT");
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine();
                result.AppendLine($"📄 Archivo: {Path.GetFileName(srtFilePath)}");
                result.AppendLine($"📏 Total de líneas: {analysis.TotalLines}");
                result.AppendLine($"🎬 Número de subtítulos: {analysis.SubtitleCount}");
                result.AppendLine($"📝 Total de palabras: {analysis.TotalWords}");
                result.AppendLine($"🔤 Total de caracteres: {analysis.TotalCharacters}");
                result.AppendLine();
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine("    INFORMACIÓN DE TIEMPO");
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine($"⏱️ Primera marca: {analysis.FirstTimestamp}");
                result.AppendLine($"⏱️ Última marca: {analysis.LastTimestamp}");
                result.AppendLine();
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine("    CONTENIDO DEL ARCHIVO");
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine();
                result.Append(string.Join(Environment.NewLine, srtLines));

                txtSrtResults.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al analizar el archivo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExtractText_Click(object sender, EventArgs e)
        {
            if (srtLines == null || srtLines.Length == 0)
            {
                MessageBox.Show("Primero debe cargar un archivo SRT.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var textOnly = ExtractTextFromSrt(srtLines);
                StringBuilder result = new StringBuilder();
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine("    TEXTO EXTRAÍDO (SIN TIMESTAMPS)");
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine();
                result.Append(string.Join(Environment.NewLine + Environment.NewLine, textOnly));

                txtSrtResults.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al extraer texto: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchSrt_Click(object sender, EventArgs e)
        {
            if (srtLines == null || srtLines.Length == 0)
            {
                MessageBox.Show("Primero debe cargar un archivo SRT.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchTerm = txtSearchSrt.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Ingrese un término de búsqueda.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var matches = SearchInSrt(srtLines, searchTerm);
                StringBuilder result = new StringBuilder();
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine($"    BÚSQUEDA: '{searchTerm}'");
                result.AppendLine("═══════════════════════════════════════");
                result.AppendLine($"🔍 Subtítulos con coincidencias: {matches.Count}");
                result.AppendLine();

                if (matches.Count > 0)
                {
                    result.AppendLine("═══════════════════════════════════════");
                    result.AppendLine("    SUBTÍTULOS ENCONTRADOS");
                    result.AppendLine("═══════════════════════════════════════");
                    result.AppendLine();

                    foreach (var match in matches)
                    {
                        result.AppendLine($"Subtítulo #{match.SubtitleNumber}");
                        result.AppendLine($"Tiempo: {match.Timestamp}");
                        result.AppendLine($"Texto: {match.Text}");
                        result.AppendLine();
                    }
                }
                else
                {
                    result.AppendLine("No se encontraron coincidencias.");
                }

                txtSrtResults.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SrtAnalysis AnalyzeSrtFile(string[] lines)
        {
            var analysis = new SrtAnalysis
            {
                TotalLines = lines.Length
            };

            int subtitleCount = 0;
            int totalWords = 0;
            int totalChars = 0;
            string? firstTimestamp = null;
            string? lastTimestamp = null;

            Regex timestampRegex = new Regex(@"\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}");

            for (int i = 0; i < lines.Length; i++)
            {
                if (int.TryParse(lines[i].Trim(), out _))
                {
                    subtitleCount++;
                }
                else if (timestampRegex.IsMatch(lines[i]))
                {
                    if (firstTimestamp == null)
                        firstTimestamp = lines[i].Trim();
                    lastTimestamp = lines[i].Trim();
                }
                else if (!string.IsNullOrWhiteSpace(lines[i]) && !int.TryParse(lines[i].Trim(), out _))
                {
                    totalWords += lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                    totalChars += lines[i].Length;
                }
            }

            analysis.SubtitleCount = subtitleCount;
            analysis.TotalWords = totalWords;
            analysis.TotalCharacters = totalChars;
            analysis.FirstTimestamp = firstTimestamp ?? "N/A";
            analysis.LastTimestamp = lastTimestamp ?? "N/A";

            return analysis;
        }

        private List<string> ExtractTextFromSrt(string[] lines)
        {
            var textLines = new List<string>();
            Regex timestampRegex = new Regex(@"\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}");

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) &&
                    !int.TryParse(line.Trim(), out _) &&
                    !timestampRegex.IsMatch(line))
                {
                    textLines.Add(line.Trim());
                }
            }

            return textLines;
        }

        private List<SrtMatch> SearchInSrt(string[] lines, string searchTerm)
        {
            var matches = new List<SrtMatch>();
            Regex timestampRegex = new Regex(@"\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}");

            int? currentSubtitleNumber = null;
            string? currentTimestamp = null;
            var currentText = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                if (int.TryParse(lines[i].Trim(), out int subtitleNum))
                {
                    if (currentSubtitleNumber.HasValue && currentText.Length > 0)
                    {
                        string text = currentText.ToString();
                        if (text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                        {
                            matches.Add(new SrtMatch
                            {
                                SubtitleNumber = currentSubtitleNumber.Value,
                                Timestamp = currentTimestamp ?? "N/A",
                                Text = text
                            });
                        }
                    }

                    currentSubtitleNumber = subtitleNum;
                    currentTimestamp = null;
                    currentText.Clear();
                }
                else if (timestampRegex.IsMatch(lines[i]))
                {
                    currentTimestamp = lines[i].Trim();
                }
                else if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    if (currentText.Length > 0)
                        currentText.Append(" ");
                    currentText.Append(lines[i].Trim());
                }
            }

            if (currentSubtitleNumber.HasValue && currentText.Length > 0)
            {
                string text = currentText.ToString();
                if (text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    matches.Add(new SrtMatch
                    {
                        SubtitleNumber = currentSubtitleNumber.Value,
                        Timestamp = currentTimestamp ?? "N/A",
                        Text = text
                    });
                }
            }

            return matches;
        }

        #endregion
    }

    #region Clases de Datos

    public class LogAnalysis
    {
        public int TotalLines { get; set; }
        public int EmptyLines { get; set; }
        public int NonEmptyLines { get; set; }
        public int ErrorCount { get; set; }
        public int WarningCount { get; set; }
        public int InfoCount { get; set; }
        public int DebugCount { get; set; }
    }

    public class LogMatch
    {
        public int LineNumber { get; set; }
        public string Content { get; set; } = string.Empty;
    }

    public class SrtAnalysis
    {
        public int TotalLines { get; set; }
        public int SubtitleCount { get; set; }
        public int TotalWords { get; set; }
        public int TotalCharacters { get; set; }
        public string FirstTimestamp { get; set; } = string.Empty;
        public string LastTimestamp { get; set; } = string.Empty;
    }

    public class SrtMatch
    {
        public int SubtitleNumber { get; set; }
        public string Timestamp { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }

    #endregion
}
