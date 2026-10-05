@echo off
chcp 65001 > nul
echo Ejecutando scripts en la base de datos...

rem -f 65001 hace que sqlcmd lea los .sql como UTF-8.
rem Sin esta opcion los acentos se guardan corruptos en la base.
for %%f in (*.sql) do (
    echo Ejecutando: %%f
    sqlcmd -S .\SQLEXPRESS -E -C -f 65001 -i "%%f"
)

echo.
echo ¡Proceso terminado con exito!
pause
