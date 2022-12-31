@echo off
@echo ...
@REM Uncomment the following line if you want to keep this BAT file for later use.
@REM copy "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\execAfter.bat" "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\execAfter_bak.bat" > NUL:
@REM If user didn't provide his own vsdocman_overrides.css in external files, copy the default (empty) one.
echo IF NOT EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\vsdocman_overrides.css" copy "C:\Program Files\VSdocman\Templates\vsdocman_overrides.css" "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\vsdocman_overrides.css" > NUL:
IF NOT EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\vsdocman_overrides.css" copy "C:\Program Files\VSdocman\Templates\vsdocman_overrides.css" "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\vsdocman_overrides.css" > NUL:
@echo Creating dynamic TOC...
echo IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\toc--" rmdir "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\toc--" /S /Q > NUL:
IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\toc--" rmdir "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\toc--" /S /Q > NUL:
@"C:\Program Files\VSdocman\Templates\HTML\Util\Helixoft.DynamicTocCreator.exe" /outputDirectory "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\toc--" "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\static_toc.xml"
@IF ERRORLEVEL 1 GOTO dynTocError
echo IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\static_toc.xml" del "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\static_toc.xml" > NUL:
IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\static_toc.xml" del "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\static_toc.xml" > NUL:
@:dynTocError
@echo Creating search index...
@"C:\Program Files\VSdocman\Templates\HTML\Util\HelixoftHtmlIndexer.exe" "C:\Dev\Core.Creditos\Core.Creditos\VSdoc" "*.htm?" "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\search--" version2
echo IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\msdn2019" rmdir "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\msdn2019" /S /Q > NUL:
IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\msdn2019" rmdir "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\msdn2019" /S /Q > NUL:
echo mkdir "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\msdn2019" > NUL:
mkdir "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\msdn2019" > NUL:
echo copy "C:\Program Files\VSdocman\Templates\msdn2019\*.*" "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\msdn2019\*.*" > NUL:
copy "C:\Program Files\VSdocman\Templates\msdn2019\*.*" "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\msdn2019\*.*" > NUL:
echo IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\SyntaxHighlighter" rmdir "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\SyntaxHighlighter" /S /Q > NUL:
IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\SyntaxHighlighter" rmdir "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\SyntaxHighlighter" /S /Q > NUL:
echo mkdir "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\SyntaxHighlighter" > NUL:
mkdir "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\SyntaxHighlighter" > NUL:
echo xcopy "C:\Program Files\VSdocman\Templates\SyntaxHighlighter\*.*" "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\SyntaxHighlighter" /S /H /R /Y /i > NUL:
xcopy "C:\Program Files\VSdocman\Templates\SyntaxHighlighter\*.*" "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\SyntaxHighlighter" /S /H /R /Y /i > NUL:
@REM HTML files that were protected against indexing will be made HTML again.
echo ren "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\*.html_rename" "*.html" > NUL:
ren "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\*.html_rename" "*.html" > NUL:
@REM delete unused files
echo IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhk" del "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhk" > NUL:
IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhk" del "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhk" > NUL:
echo IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhc" del "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhc" > NUL:
IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhc" del "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhc" > NUL:
echo IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhp" del "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhp" > NUL:
IF EXIST "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhp" del "C:\Dev\Core.Creditos\Core.Creditos\VSdoc\Core.Creditos.hhp" > NUL:
@echo All done
