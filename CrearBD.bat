@echo off
chcp 65001 > nul
echo ==========================================
echo  Creando y poblando Base de Datos GU_Tercero...
echo ==========================================
sqlcmd -S .\SQLEXPRESS -i "%~dp000_CREAR_Y_CARGAR_BD_GU_TERCERO.sql" -b
if %ERRORLEVEL% EQU 0 (
    echo.
    echo [ÉXITO] La Base de Datos GU_Tercero se creó y cargó correctamente.
    echo Usuario: admin
    echo Contraseña: Esty123
) else (
    echo.
    echo [ERROR] Ocurrió un error al ejecutar el script en SQL Server (.\SQLEXPRESS).
)
echo.
pause
