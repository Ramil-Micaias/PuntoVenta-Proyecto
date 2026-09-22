@echo off
echo ==========================================
echo Creando y poblando Base de Datos GU_Tercero...
echo ==========================================
sqlcmd -S .\SQLEXPRESS -i "%~dp000_CREAR_Y_CARGAR_BD_GU_TERCERO.sql" -b
if errorlevel 1 goto error
echo.
echo [EXITO] La Base de Datos GU_Tercero se creo y cargo correctamente.
echo Usuario: admin
echo Contrasena: Esty123
goto fin

:error
echo.
echo [ERROR] Ocurrio un error al ejecutar el script en SQL Server (.\SQLEXPRESS).

:fin
echo.
pause
