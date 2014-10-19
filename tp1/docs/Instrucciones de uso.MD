# Teoría de Algoritmos - TP1

## Prerequisitos

### Windows

- Visual Studio 2010 o superior ([http://go.microsoft.com/?linkid=9832437&clcid=0x409](http://go.microsoft.com/?linkid=9832437&clcid=0x409 "descarga"))
- NUnit para los tests unitarios ([http://launchpad.net/nunitv2/trunk/2.6.3/+download/NUnit-2.6.3.msi](http://launchpad.net/nunitv2/trunk/2.6.3/+download/NUnit-2.6.3.msi "descarga"))

### Linux
- Mono 2.1 o superior ([http://www.mono-project.com/download/#download-lin](http://www.mono-project.com/download/#download-lin "descarga"))
- NUnit para los tests unitarios ([http://launchpad.net/nunitv2/trunk/2.6.3/+download/NUnit-2.6.3.zip](http://launchpad.net/nunitv2/trunk/2.6.3/+download/NUnit-2.6.3.zip "descarga"))


## Instrucciones de Uso

### Windows
1. Abrir Visual Studio.
2. Compilar la solución **TP1.sln** en modo *Release*.
2. Abrir el archivo de configuración **ConsoleApplication.exe.config** que se encuentra dentro de la carpeta **tp1\src\ConsoleApplication\bin\Release**.
3. Modificar el valor del parámetro `inputFilePath` con el path completo al archivo GDF a analizar. (Como archivo de prueba se puede utilizar **tp1\src\tp1\ConsoleApplication\Input\miparnisari.gdf**)

### Linux
1. En la carpeta **tp1/src**, ejecutar los comandos:

>     ./configure
>     make

2. Abrir el archivo de configuración **ConsoleApplication.exe.config** que se encuentra dentro de la carpeta **tp1\src\ConsoleApplication\bin\Release**.
3. Modificar el valor del parámetro `inputFilePath` con el path completo al archivo GDF a analizar. (Como archivo de prueba se puede utilizar el archivo **tp1\src\tp1\ConsoleApplication\Input\miparnisari.gdf**)
4. En la carpeta **ConsoleApplication\bin\Release** ejecutar el siguiente comando:

>     ./ConsoleApplication.exe




