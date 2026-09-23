@echo off
chcp 65001 > nul
echo Ejecutando scripts en la base de datos...

for %%f in (*.sql) do (
    echo Ejecutando: %%f
    sqlcmd -S .\SQLEXPRESS -E -C -i "%%f"
)

echo.
echo ¡Proceso terminado con exito!
pause