# 📄 Documentación - Procesamiento de Archivos No Estructurados

## 📋 Índice
1. [Descripción General](#descripción-general)
2. [Interfaz de Usuario](#interfaz-de-usuario)
3. [Funcionalidades por Pestaña](#funcionalidades-por-pestaña)
4. [Métodos Principales](#métodos-principales)
5. [Clases de Datos](#clases-de-datos)
6. [Ejemplos de Uso](#ejemplos-de-uso)

---

## 🎯 Descripción General

Esta aplicación de Windows Forms (.NET 8) está diseñada para procesar y analizar archivos de datos **no estructurados**, específicamente:

- **Archivos .LOG**: Registros de eventos de sistemas o aplicaciones
- **Archivos .SRT**: Archivos de subtítulos para videos

Los datos no estructurados son aquellos que no tienen un esquema fijo predefinido, como bases de datos relacionales. Requieren técnicas especiales de análisis textual para extraer información útil.

---

## 🖥️ Interfaz de Usuario

### Estructura Principal

La aplicación utiliza un control **TabControl** con dos pestañas:

1. **Pestaña "Procesamiento .LOG"**
2. **Pestaña "Procesamiento .SRT"**

Cada pestaña contiene:
- Panel superior con botones de acción
- Área de texto grande para mostrar resultados (fuente Consolas para mejor legibilidad)

---

## 🔧 Funcionalidades por Pestaña

### 📊 Pestaña: Procesamiento .LOG

#### **Botón: "Cargar Archivo .LOG"**
**Método asociado:** `btnLoadLog_Click`

**¿Qué hace al presionarlo?**
1. Abre un cuadro de diálogo para seleccionar un archivo .log
2. Lee todas las líneas del archivo seleccionado
3. Almacena las líneas en memoria (`logLines`)
4. Muestra el contenido completo en el área de texto
5. Presenta un mensaje con el número total de líneas cargadas

**Resultado visual:**
```
[Cuadro de diálogo de archivo]
→ Usuario selecciona "ejemplo.log"
→ Contenido del archivo se muestra en txtLogResults
→ Mensaje: "Archivo cargado exitosamente. Líneas totales: 20"
```

---

#### **Botón: "Analizar LOG"**
**Método asociado:** `btnAnalyzeLog_Click`

**¿Qué hace al presionarlo?**
1. Verifica que haya un archivo cargado
2. Analiza el contenido del archivo buscando:
   - Total de líneas
   - Líneas vacías y con contenido
   - Ocurrencias de palabras clave: ERROR, WARNING, INFO, DEBUG
3. Genera un reporte formateado con estadísticas
4. Muestra el reporte seguido del contenido original

**Resultado visual:**
```
═══════════════════════════════════════
    ANÁLISIS DE ARCHIVO LOG
═══════════════════════════════════════

📄 Archivo: ejemplo.log
📏 Total de líneas: 20
📝 Líneas con contenido: 20
⚪ Líneas vacías: 0

═══════════════════════════════════════
    ESTADÍSTICAS POR NIVEL
═══════════════════════════════════════
🔴 ERROR:   4 ocurrencias
🟡 WARNING: 3 ocurrencias
🟢 INFO:    10 ocurrencias
🔵 DEBUG:   3 ocurrencias
```

---

#### **Campo de Texto: "Buscar término"**
Campo de entrada para escribir el término a buscar (ej: "ERROR", "WARNING")

#### **Botón: "Buscar"**
**Método asociado:** `btnSearchLog_Click`

**¿Qué hace al presionarlo?**
1. Verifica que haya un archivo cargado
2. Obtiene el término de búsqueda del campo de texto
3. Busca el término en todas las líneas del archivo (sin distinguir mayúsculas/minúsculas)
4. Genera un reporte con:
   - Número total de coincidencias
   - Número de línea y contenido de cada coincidencia

**Resultado visual:**
```
═══════════════════════════════════════
    BÚSQUEDA: 'ERROR'
═══════════════════════════════════════
🔍 Coincidencias encontradas: 4

═══════════════════════════════════════
    LÍNEAS ENCONTRADAS
═══════════════════════════════════════

Línea 7: 2024-01-15 10:25:30 [ERROR] No se pudo conectar al servicio externo

Línea 8: 2024-01-15 10:25:31 [ERROR] TimeoutException: La operación excedió el tiempo límite

Línea 13: 2024-01-15 10:28:10 [ERROR] NullReferenceException en módulo de reportes

Línea 14: 2024-01-15 10:28:11 [ERROR] Stack trace: at ReportModule.Generate()
```

---

### 🎬 Pestaña: Procesamiento .SRT

#### **Botón: "Cargar Archivo .SRT"**
**Método asociado:** `btnLoadSrt_Click`

**¿Qué hace al presionarlo?**
1. Abre un cuadro de diálogo para seleccionar un archivo .srt
2. Lee todas las líneas del archivo seleccionado
3. Almacena las líneas en memoria (`srtLines`)
4. Muestra el contenido completo en el área de texto
5. Presenta un mensaje con el número total de líneas cargadas

**Estructura de un archivo .SRT:**
```
1                                    ← Número de subtítulo
00:00:01,000 --> 00:00:04,500       ← Marca de tiempo
Bienvenidos al curso                 ← Texto del subtítulo
de archivos no estructurados         ← (puede tener múltiples líneas)
                                     ← Línea vacía separadora
2
00:00:05,000 --> 00:00:08,200
En esta lección aprenderemos
```

---

#### **Botón: "Analizar SRT"**
**Método asociado:** `btnAnalyzeSrt_Click`

**¿Qué hace al presionarlo?**
1. Verifica que haya un archivo cargado
2. Analiza el contenido utilizando expresiones regulares para identificar:
   - Números de subtítulos
   - Marcas de tiempo (timestamps)
   - Texto de subtítulos
3. Calcula estadísticas:
   - Total de líneas
   - Número de subtítulos
   - Total de palabras
   - Total de caracteres
   - Primera y última marca de tiempo
4. Genera un reporte formateado

**Resultado visual:**
```
═══════════════════════════════════════
    ANÁLISIS DE ARCHIVO SRT
═══════════════════════════════════════

📄 Archivo: ejemplo.srt
📏 Total de líneas: 44
🎬 Número de subtítulos: 11
📝 Total de palabras: 89
🔤 Total de caracteres: 502

═══════════════════════════════════════
    INFORMACIÓN DE TIEMPO
═══════════════════════════════════════
⏱️ Primera marca: 00:00:01,000 --> 00:00:04,500
⏱️ Última marca: 00:00:43,500 --> 00:00:46,500
```

---

#### **Botón: "Extraer Solo Texto"**
**Método asociado:** `btnExtractText_Click`

**¿Qué hace al presionarlo?**
1. Verifica que haya un archivo cargado
2. Filtra el contenido eliminando:
   - Números de subtítulos
   - Marcas de tiempo
   - Líneas vacías
3. Extrae únicamente el texto de los subtítulos
4. Muestra el texto limpio, separando cada subtítulo con líneas en blanco

**Resultado visual:**
```
═══════════════════════════════════════
    TEXTO EXTRAÍDO (SIN TIMESTAMPS)
═══════════════════════════════════════

Bienvenidos al curso de procesamiento
de archivos no estructurados

En esta lección aprenderemos a trabajar
con diferentes tipos de datos

Los archivos LOG contienen información
sobre eventos del sistema
```

---

#### **Campo de Texto: "Buscar texto"**
Campo de entrada para escribir el texto a buscar en los subtítulos

#### **Botón: "Buscar"**
**Método asociado:** `btnSearchSrt_Click`

**¿Qué hace al presionarlo?**
1. Verifica que haya un archivo cargado
2. Obtiene el término de búsqueda del campo de texto
3. Recorre todos los subtítulos buscando coincidencias (sin distinguir mayúsculas/minúsculas)
4. Para cada coincidencia, captura:
   - Número de subtítulo
   - Marca de tiempo
   - Texto completo del subtítulo
5. Genera un reporte con todos los subtítulos que contienen el término

**Resultado visual:**
```
═══════════════════════════════════════
    BÚSQUEDA: 'archivos'
═══════════════════════════════════════
🔍 Subtítulos con coincidencias: 3

═══════════════════════════════════════
    SUBTÍTULOS ENCONTRADOS
═══════════════════════════════════════

Subtítulo #1
Tiempo: 00:00:01,000 --> 00:00:04,500
Texto: Bienvenidos al curso de procesamiento de archivos no estructurados

Subtítulo #3
Tiempo: 00:00:09,000 --> 00:00:12,800
Texto: Los archivos LOG contienen información sobre eventos del sistema

Subtítulo #4
Tiempo: 00:00:13,500 --> 00:00:17,300
Texto: Mientras que los archivos SRT son utilizados para subtítulos
```

---

## 🛠️ Métodos Principales

### Procesamiento de Archivos .LOG

#### `btnLoadLog_Click(object sender, EventArgs e)`
**Propósito:** Manejador del evento Click del botón "Cargar Archivo .LOG"

**Funcionamiento:**
1. Crea un `OpenFileDialog` con filtro para archivos .log
2. Si el usuario selecciona un archivo:
   - Lee todas las líneas usando `File.ReadAllLines()`
   - Almacena en `logLines` (variable de instancia)
   - Muestra el contenido en `txtLogResults`
   - Muestra mensaje de éxito con el conteo de líneas
3. Maneja excepciones mostrando mensajes de error

**Variables utilizadas:**
- `logFilePath`: Ruta del archivo cargado
- `logLines`: Array con todas las líneas del archivo

---

#### `btnAnalyzeLog_Click(object sender, EventArgs e)`
**Propósito:** Manejador del evento Click del botón "Analizar LOG"

**Funcionamiento:**
1. Valida que exista un archivo cargado
2. Llama al método `AnalyzeLogFile()` para obtener estadísticas
3. Construye un reporte formateado usando `StringBuilder`
4. Muestra el reporte seguido del contenido original

---

#### `AnalyzeLogFile(string[] lines)`
**Propósito:** Analiza las líneas del archivo log y genera estadísticas

**Parámetros:**
- `lines`: Array de strings con las líneas del archivo

**Retorna:** Objeto `LogAnalysis` con las estadísticas

**Funcionamiento:**
1. Cuenta líneas totales, vacías y con contenido
2. Recorre cada línea buscando palabras clave:
   - "ERROR" → incrementa `ErrorCount`
   - "WARNING" o "WARN" → incrementa `WarningCount`
   - "INFO" → incrementa `InfoCount`
   - "DEBUG" → incrementa `DebugCount`
3. La búsqueda es insensible a mayúsculas/minúsculas

**Código clave:**
```csharp
foreach (var line in lines)
{
    string upperLine = line.ToUpper();
    if (upperLine.Contains("ERROR")) analysis.ErrorCount++;
    if (upperLine.Contains("WARNING") || upperLine.Contains("WARN")) analysis.WarningCount++;
    if (upperLine.Contains("INFO")) analysis.InfoCount++;
    if (upperLine.Contains("DEBUG")) analysis.DebugCount++;
}
```

---

#### `btnSearchLog_Click(object sender, EventArgs e)`
**Propósito:** Manejador del evento Click del botón "Buscar" en pestaña LOG

**Funcionamiento:**
1. Valida que exista un archivo cargado
2. Obtiene el término de búsqueda de `txtSearchLog.Text`
3. Valida que no esté vacío
4. Llama a `SearchInLog()` para buscar coincidencias
5. Genera reporte con resultados

---

#### `SearchInLog(string[] lines, string searchTerm)`
**Propósito:** Busca un término en todas las líneas del log

**Parámetros:**
- `lines`: Array de líneas del archivo
- `searchTerm`: Término a buscar

**Retorna:** `List<LogMatch>` con las líneas que coinciden

**Funcionamiento:**
1. Itera sobre todas las líneas con su índice
2. Usa `Contains()` con `StringComparison.OrdinalIgnoreCase` (ignora mayúsculas/minúsculas)
3. Para cada coincidencia, crea un objeto `LogMatch` con:
   - Número de línea (índice + 1)
   - Contenido de la línea

**Código clave:**
```csharp
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
```

---

### Procesamiento de Archivos .SRT

#### `btnLoadSrt_Click(object sender, EventArgs e)`
**Propósito:** Manejador del evento Click del botón "Cargar Archivo .SRT"

**Funcionamiento:**
- Similar a `btnLoadLog_Click`, pero para archivos .srt
- Utiliza filtro de archivos .srt en el diálogo
- Almacena líneas en `srtLines`

---

#### `btnAnalyzeSrt_Click(object sender, EventArgs e)`
**Propósito:** Manejador del evento Click del botón "Analizar SRT"

**Funcionamiento:**
1. Valida que exista un archivo cargado
2. Llama a `AnalyzeSrtFile()` para obtener estadísticas
3. Genera reporte formateado
4. Muestra estadísticas y contenido original

---

#### `AnalyzeSrtFile(string[] lines)`
**Propósito:** Analiza la estructura del archivo SRT y extrae estadísticas

**Parámetros:**
- `lines`: Array con todas las líneas del archivo

**Retorna:** Objeto `SrtAnalysis` con las estadísticas

**Funcionamiento:**
1. **Expresión Regular para timestamps:**
   ```csharp
   Regex timestampRegex = new Regex(@"\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}");
   ```
   - Busca el patrón: `00:00:01,000 --> 00:00:04,500`

2. **Identificación de elementos:**
   - Si la línea es un número → es un número de subtítulo (incrementa contador)
   - Si coincide con el patrón de timestamp → captura primera y última marca
   - Si tiene texto y no es número → cuenta palabras y caracteres

3. **Conteo de palabras:**
   ```csharp
   totalWords += lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
   ```

---

#### `btnExtractText_Click(object sender, EventArgs e)`
**Propósito:** Manejador del evento Click del botón "Extraer Solo Texto"

**Funcionamiento:**
1. Valida que exista un archivo cargado
2. Llama a `ExtractTextFromSrt()` para filtrar solo el texto
3. Muestra el texto extraído con separadores entre subtítulos

---

#### `ExtractTextFromSrt(string[] lines)`
**Propósito:** Extrae únicamente el texto de los subtítulos, eliminando metadatos

**Parámetros:**
- `lines`: Array de líneas del archivo

**Retorna:** `List<string>` con solo las líneas de texto

**Funcionamiento:**
1. Usa la misma expresión regular para identificar timestamps
2. Filtra líneas que NO sean:
   - Vacías o con solo espacios
   - Números (números de subtítulos)
   - Timestamps
3. Agrega solo las líneas de texto a la lista

**Código clave:**
```csharp
foreach (var line in lines)
{
    if (!string.IsNullOrWhiteSpace(line) &&
        !int.TryParse(line.Trim(), out _) &&
        !timestampRegex.IsMatch(line))
    {
        textLines.Add(line.Trim());
    }
}
```

---

#### `btnSearchSrt_Click(object sender, EventArgs e)`
**Propósito:** Manejador del evento Click del botón "Buscar" en pestaña SRT

**Funcionamiento:**
1. Valida que exista un archivo cargado
2. Obtiene el término de búsqueda de `txtSearchSrt.Text`
3. Valida que no esté vacío
4. Llama a `SearchInSrt()` para buscar en subtítulos
5. Genera reporte con subtítulos completos que contienen el término

---

#### `SearchInSrt(string[] lines, string searchTerm)`
**Propósito:** Busca un término en los subtítulos y retorna subtítulos completos

**Parámetros:**
- `lines`: Array de líneas del archivo
- `searchTerm`: Término a buscar

**Retorna:** `List<SrtMatch>` con los subtítulos que contienen el término

**Funcionamiento:**
Este método es más complejo porque debe reconstruir los subtítulos completos:

1. **Variables de estado:**
   ```csharp
   int? currentSubtitleNumber = null;
   string? currentTimestamp = null;
   var currentText = new StringBuilder();
   ```

2. **Lógica de procesamiento:**
   - Si encuentra un número → inicia un nuevo subtítulo
   - Si encuentra un timestamp → lo almacena
   - Si encuentra texto → lo agrega al texto actual
   - Cuando cambia de subtítulo → verifica si el texto anterior contiene el término buscado

3. **Reconstrucción del texto:**
   ```csharp
   if (currentText.Length > 0)
       currentText.Append(" ");
   currentText.Append(lines[i].Trim());
   ```

4. **Validación final:** Al terminar el archivo, verifica el último subtítulo

---

## 📊 Clases de Datos

### `LogAnalysis`
**Propósito:** Almacenar estadísticas del análisis de archivos LOG

**Propiedades:**
```csharp
public int TotalLines { get; set; }       // Total de líneas en el archivo
public int EmptyLines { get; set; }       // Líneas vacías o con solo espacios
public int NonEmptyLines { get; set; }    // Líneas con contenido
public int ErrorCount { get; set; }       // Número de líneas con "ERROR"
public int WarningCount { get; set; }     // Número de líneas con "WARNING" o "WARN"
public int InfoCount { get; set; }        // Número de líneas con "INFO"
public int DebugCount { get; set; }       // Número de líneas con "DEBUG"
```

---

### `LogMatch`
**Propósito:** Representar una línea que coincide con un término de búsqueda

**Propiedades:**
```csharp
public int LineNumber { get; set; }       // Número de línea (1-based)
public string Content { get; set; }       // Contenido completo de la línea
```

---

### `SrtAnalysis`
**Propósito:** Almacenar estadísticas del análisis de archivos SRT

**Propiedades:**
```csharp
public int TotalLines { get; set; }          // Total de líneas en el archivo
public int SubtitleCount { get; set; }       // Número total de subtítulos
public int TotalWords { get; set; }          // Total de palabras en todos los subtítulos
public int TotalCharacters { get; set; }     // Total de caracteres
public string FirstTimestamp { get; set; }   // Primera marca de tiempo del video
public string LastTimestamp { get; set; }    // Última marca de tiempo del video
```

---

### `SrtMatch`
**Propósito:** Representar un subtítulo que coincide con un término de búsqueda

**Propiedades:**
```csharp
public int SubtitleNumber { get; set; }   // Número del subtítulo
public string Timestamp { get; set; }     // Marca de tiempo (00:00:01,000 --> 00:00:04,500)
public string Text { get; set; }          // Texto completo del subtítulo
```

---

## 📖 Ejemplos de Uso

### Ejemplo 1: Analizar un archivo LOG

1. **Ejecutar la aplicación**
2. **Ir a la pestaña "Procesamiento .LOG"**
3. **Presionar "Cargar Archivo .LOG"** → Seleccionar `ejemplo.log`
4. **Presionar "Analizar LOG"**

**Resultado esperado:**
```
═══════════════════════════════════════
    ANÁLISIS DE ARCHIVO LOG
═══════════════════════════════════════

📄 Archivo: ejemplo.log
📏 Total de líneas: 20
📝 Líneas con contenido: 20
⚪ Líneas vacías: 0

═══════════════════════════════════════
    ESTADÍSTICAS POR NIVEL
═══════════════════════════════════════
🔴 ERROR:   4 ocurrencias
🟡 WARNING: 3 ocurrencias
🟢 INFO:    10 ocurrencias
🔵 DEBUG:   3 ocurrencias
```

---

### Ejemplo 2: Buscar errores en el LOG

1. **Con el archivo cargado**
2. **Escribir "ERROR" en el campo "Buscar término"**
3. **Presionar "Buscar"**

**Resultado esperado:**
- Lista de todas las líneas que contienen "ERROR"
- Muestra el número de línea y contenido completo

---

### Ejemplo 3: Analizar un archivo SRT

1. **Ir a la pestaña "Procesamiento .SRT"**
2. **Presionar "Cargar Archivo .SRT"** → Seleccionar `ejemplo.srt`
3. **Presionar "Analizar SRT"**

**Resultado esperado:**
```
═══════════════════════════════════════
    ANÁLISIS DE ARCHIVO SRT
═══════════════════════════════════════

📄 Archivo: ejemplo.srt
📏 Total de líneas: 44
🎬 Número de subtítulos: 11
📝 Total de palabras: 89
🔤 Total de caracteres: 502

═══════════════════════════════════════
    INFORMACIÓN DE TIEMPO
═══════════════════════════════════════
⏱️ Primera marca: 00:00:01,000 --> 00:00:04,500
⏱️ Última marca: 00:00:43,500 --> 00:00:46,500
```

---

### Ejemplo 4: Extraer solo texto de subtítulos

1. **Con el archivo SRT cargado**
2. **Presionar "Extraer Solo Texto"**

**Resultado esperado:**
- Muestra solo el texto de los subtítulos
- Sin números de subtítulo
- Sin marcas de tiempo
- Subtítulos separados por líneas en blanco

---

### Ejemplo 5: Buscar palabra en subtítulos

1. **Con el archivo SRT cargado**
2. **Escribir "archivos" en el campo "Buscar texto"**
3. **Presionar "Buscar"**

**Resultado esperado:**
- Lista de subtítulos completos que contienen "archivos"
- Para cada coincidencia muestra:
  - Número de subtítulo
  - Marca de tiempo
  - Texto completo

---

## 🔍 Detalles Técnicos

### Expresiones Regulares Utilizadas

#### Timestamp de SRT
```csharp
Regex timestampRegex = new Regex(@"\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{3}");
```

**Explicación del patrón:**
- `\d{2}` = dos dígitos (horas, minutos, segundos)
- `:` = dos puntos literales
- `,` = coma literal
- `\d{3}` = tres dígitos (milisegundos)
- ` --> ` = separador literal

**Ejemplo de coincidencia:** `00:00:01,000 --> 00:00:04,500`

---

### Manejo de Excepciones

Todos los métodos que interactúan con archivos incluyen bloques try-catch:

```csharp
try
{
    // Operación con archivos
}
catch (Exception ex)
{
    MessageBox.Show($"Error: {ex.Message}",
        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

**Excepciones comunes:**
- `FileNotFoundException`: Archivo no existe
- `IOException`: Problemas de lectura/escritura
- `UnauthorizedAccessException`: Sin permisos
- `ArgumentException`: Ruta inválida

---

### Validaciones Implementadas

Antes de procesar archivos, se valida:

```csharp
if (logLines == null || logLines.Length == 0)
{
    MessageBox.Show("Primero debe cargar un archivo LOG.",
        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
}
```

---

## 🎨 Formato de Salida

### Caracteres Especiales Utilizados

- `═` = Líneas de separación decorativas
- 📄 📏 📝 = Emojis de documentación
- 🔴 🟡 🟢 🔵 = Indicadores de nivel de log
- 🎬 = Información de video/subtítulos
- 🔍 = Resultados de búsqueda
- ⏱️ = Información temporal

---

## 🚀 Flujo de Trabajo Recomendado

### Para Archivos LOG:
1. Cargar archivo
2. Analizar para ver estadísticas generales
3. Si hay muchos errores → Buscar "ERROR"
4. Si hay advertencias → Buscar "WARNING"

### Para Archivos SRT:
1. Cargar archivo
2. Analizar para ver duración y cantidad de subtítulos
3. Extraer texto si solo necesitas el contenido
4. Buscar palabras clave para encontrar diálogos específicos

---

## 📝 Notas Importantes

1. **Los archivos no se modifican**, solo se leen
2. **La búsqueda no distingue mayúsculas/minúsculas**
3. **Los archivos se mantienen en memoria** mientras la aplicación esté abierta
4. **Se pueden cargar diferentes archivos** sin reiniciar la aplicación
5. **Los resultados se sobrescriben** cada vez que se ejecuta una nueva acción

---

## 🎓 Conceptos de Datos No Estructurados

### ¿Por qué son "no estructurados"?

**Archivos LOG:**
- No tienen un formato fijo estándar
- Cada aplicación puede escribir logs de forma diferente
- No hay campos predefinidos como en una base de datos
- El análisis depende de patrones de texto

**Archivos SRT:**
- Aunque tienen una estructura (número, tiempo, texto)
- No usan un esquema formal como XML o JSON
- El texto puede tener múltiples líneas sin límite
- No hay validación de estructura incorporada

---

## 👨‍💻 Desarrollador

**Tecnologías utilizadas:**
- .NET 8
- Windows Forms
- C# 12
- System.Text.RegularExpressions

**Dependencias:**
- Ninguna (solo .NET Framework estándar)

---

## 📄 Licencia

Aplicación de ejemplo educativa para demostración de procesamiento de datos no estructurados.

---

**Fecha de creación:** 2024  
**Versión:** 1.0  
**Framework:** .NET 8.0
