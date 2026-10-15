@echo off
chcp 65001 > nul
echo Ejecutando scripts en la base de datos...

rem Los scripts se ejecutan en orden numerico explicito.
rem -f 65001 hace que sqlcmd lea los .sql como UTF-8.
rem Sin esta opcion los acentos se guardan corruptos en la base.

sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp001_Tablas.sql"
sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp002_Tabla_ApIBigStored.sql"
sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp003_StoreProcedure.sql"
sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp004_SP_Producto.sql"
sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp005_SP_Proveedor.sql"
sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp006_DatosIniciales.sql"
sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp007_DatosIniciales_ApIBigStored.sql"
sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp008_Categorias_Iniciales.sql"
sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp009_Insertar_Productos.sql"
sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp010_SP_Compra.sql"
sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%~dp011_SP_Venta.sql"

echo.
echo ¡Proceso terminado con exito!
pause
