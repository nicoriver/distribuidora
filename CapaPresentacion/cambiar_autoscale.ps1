# Script para cambiar AutoScaleMode en todos los formularios Designer.cs
# Autor: Sistema
# Fecha: 2026-02-04

Write-Host "==================================================" -ForegroundColor Cyan
Write-Host "  Cambiar AutoScaleMode.Font a AutoScaleMode.Dpi" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan
Write-Host ""

$files = Get-ChildItem -Path . -Filter "*.Designer.cs" -Recurse

$totalFiles = $files.Count
$updatedFiles = 0

foreach ($file in $files) {
    $content = Get-Content $file.FullName -Raw -Encoding UTF8
    
    # Cambiar AutoScaleMode.Font a AutoScaleMode.Dpi
    $newContent = $content -replace 'this\.AutoScaleMode = System\.Windows\.Forms\.AutoScaleMode\.Font;', 'this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;'
    
    if ($content -ne $newContent) {
        Set-Content -Path $file.FullName -Value $newContent -Encoding UTF8
        Write-Host "[OK] Actualizado: $($file.Name)" -ForegroundColor Green
        $updatedFiles++
    } else {
        Write-Host "[--] Sin cambios: $($file.Name)" -ForegroundColor Gray
    }
}

Write-Host ""
Write-Host "==================================================" -ForegroundColor Cyan
Write-Host "  Proceso completado!" -ForegroundColor Cyan
Write-Host "  Total de archivos: $totalFiles" -ForegroundColor White
Write-Host "  Archivos actualizados: $updatedFiles" -ForegroundColor Green
Write-Host "==================================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Presiona cualquier tecla para salir..." -ForegroundColor Yellow
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
