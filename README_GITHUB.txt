СБОРКА EXE ЧЕРЕЗ GITHUB

1. Откройте https://github.com и войдите в аккаунт.
2. Нажмите + (вверху справа) -> New repository.
3. Назовите репозиторий, например Slesar-remontnik-NOK. Выберите Public или Private.
4. Нажмите Create repository.
5. На странице репозитория нажмите Add file -> Upload files.
6. Распакуйте этот архив на компьютере. Перетащите ВСЁ содержимое папки проекта
   в окно GitHub Upload files. ВАЖНО: вместе с файлами нужно загрузить скрытую
   папку .github и файл внутри .github/workflows/build-windows.yml.
   Если папка .github не видна в Проводнике, включите Вид -> Показать -> Скрытые элементы.
7. Внизу страницы нажмите Commit changes.
8. Откройте вкладку Actions. Выберите workflow Build Windows EXE.
   Если сборка после загрузки не стартовала сама, нажмите Run workflow -> Run workflow.
9. Дождитесь зелёной галочки (обычно несколько минут). Откройте завершённый запуск.
10. Внизу страницы найдите Artifacts и скачайте Slesar-remontnik-NOK-Windows-x64.
    Распакуйте ZIP. Внутри будут EXE и HTML-файл. Не отделяйте их друг от друга.

Примечание: репозиторий можно сделать Private. Сборка выполняется на Windows-сервере GitHub.
Для запуска программы на компьютере нужен Microsoft Edge WebView2 Runtime.
