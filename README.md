TgBotMusicCentre 

TgBotMusicCentre is an educational bot written in C# using the Telegram.Bot API, designed for a music school. The bot helps users to:

Learn information about classes in singing, painting, and music recording

View class schedules

Get information about teachers

Contact the administration via the "Contact Us" button

The bot supports interactive menus and inline buttons, allowing users to quickly navigate between sections.

⚡ Features

Home page with a welcome message and buttons:

Singing 🎤

Painting 🎨

Recording 🎧

About 📖

Contact 💬

Sections with information about teachers for each category

Class schedules for each category

“Back” buttons to return to the previous menu

Use of EditMessageTextAsync to update messages instead of sending new ones

🛠 Technologies

C# 11 / .NET 9

Telegram.Bot API

Async / Await for asynchronous bot operations

Clean architecture with project separation:

BotHandler — main handler for starting and processing messages

BusinessLogic — command and message logic

ModelsForBot — interfaces and menu structures
About 📖

Contact 💬


