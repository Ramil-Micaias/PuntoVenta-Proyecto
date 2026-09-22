$sqlFile = Join-Path -Path $PSScriptRoot -ChildPath "00_CREAR_Y_CARGAR_BD_GU_TERCERO.sql"
Write-Host "==========================================" -ForegroundColor Cyan
Write-Host " Creando y poblando Base de Datos GU_Tercero..." -ForegroundColor Yellow
Write-Host "==========================================" -ForegroundColor Cyan

try {
    sqlcmd -S ".\SQLEXPRESS" -i "$sqlFile" -b
    if ($LASTEXITCODE -eq 0) {
        Write-Host "`n[EXITO] La Base de Datos GU_Tercero fue creada y cargada correctamente." -ForegroundColor Green
        Write-Host "Usuario por defecto: admin" -ForegroundColor White
        Write-Host "Contrasena por defecto: Esty123" -ForegroundColor White
    } else {
        Write-Host "`n[ERROR] Ocurrio un inconveniente al ejecutar sqlcmd." -ForegroundColor Red
    }
} catch {
    Write-Host "`n[ERROR] No se pudo conectar con SQL Server local (.\SQLEXPRESS)." -ForegroundColor Red
    Write-Host $_.Exception.Message -ForegroundColor Red
}

Write-Host "`nPresione cualquier tecla para salir..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
