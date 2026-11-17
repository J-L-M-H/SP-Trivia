# SP-Trivia
Grupp-projekt objektorienterad programmering


Quiz Battle 

Om projektet 

Quiz Battle är ett konsolbaserat frågesportspel där 2 till 4 spelare kan tävla mot varandra. Spelet går ut på att svara rätt på frågor inom olika kategorier och samla så många poäng som möjligt. 

Spelarna kan välja vilken kategori de vill få frågor från eller låta spelet välja slumpmässigt. Frågorna har olika svårighetsgrader och ger olika mycket poäng beroende på svårigheten. Frågorna är sparade i JSON-format och innehåller information om frågetyp, kategori, frågetext, svarsalternativ och svårighetsgrad. 

Poängsystem 

Lätt 10 Medel 20 Svår 30 

Vid flera rätta svar i rad får spelaren seriebonus: 

Andra rätta svaret i rad: +5 poäng. 

Tredje rätta svaret i rad: +10 poäng. 

Fjärde rätta svaret i rad: +15 poäng. 

Femte och följande rätta svar i rad: +20 poäng. 

Ett felaktigt svar nollställer serien. 

Efter spelet visas slutresultatet och vinnaren. Resultaten sparas även i en topplista. 

Funktioner 

1- 2–4 spelare kan delta i samma spel. 

2- Spelarna anger sina namn och antal rundor. 

3- Frågor finns i olika kategorier i questions.json. 

4- Det finns flervalsfrågor och sant eller falskt-frågor. 

5- Spelarna kan välja kategori eller slumpmässigt val. 

6- Frågorna har tre svårighetsgrader: lätt, medel och svår. 

7- Poängsystem med seriebonus för flera rätta svar i rad. 

8- Frågor kan inte användas flera gånger under samma spel. 

9- Resultatet visas efter sista rundan. 

10- Vid lika poäng avgör antalet rätta svar vem som vinner. 

11-Resultaten sparas i en JSON-fil och visas i topplistan. 

Teknik 

Projektet är utvecklat i C# och använder objektorienterad programmering. 

Vi använder bland annat: 

1- Klasser och objekt. 

2- Arv. 

3- Interface. 

4- Listor och samlingar. 

5- LINQ för att filtrera och sortera frågor och spelare. 

6- JSON för att läsa frågor och spara resultat. 

Förutsättningar 

För att kunna köra projektet behöver du: 

1- .NET SDK installerat. 

2- Git för att hämta projektet från GitHub. 

3- Visual Studio (vscode) eller Visual Studio Code.

4- Sätta json filerna i data mappen till "Always copy".

Så här gör du: 

1- Öppna terminalen och klona projektet från GitHub: git clone https://github.com/J-L-M-H/SP-Trivia.git 

2- Gå sedan in i projektmappen SP-Trivia 

3- Kör följande kommando i terminalen för att bygga projektet: dotnet build 

4- Starta spelet med: dotnet run 

Spelregler 

1- Välj Spela i huvudmenyn. 

2- Ange antal spelare. 

3- Skriv in spelarnas namn. 

4- Välj antal rundor. 

5- Varje spelare väljer en kategori eller slumpmässigt val. 

6- Svara på frågan och samla poäng. 

7- När alla rundor är klara visas slutresultatet. 

7- Resultaten sparas i topplistan. 

 
Program.cs

Author Rami

Huvudmeny. När programmet startar skapas ett objekt av HighScore, som hämtar tidigare sparade resultat. Därefter skapas ett objekt av GameLogic, som får tillgång till topplistan. I huvudmenyn kan spelaren välja att starta ett nytt spel, visa topplistan eller avsluta programmet. Jag använder en while-loop för att menyn ska visas igen tills användaren väljer att avsluta.
 
 

Branch feature/Player 

Author Bryan 

Player-klassen representerar en spelare i Quiz Battle och ansvarar för att lagra spelarens namn, poäng antal korrekta svar, svarsstreak samt datum och tid då spelarobjektet skapades. Klassen innehåller en konstruktor som initierar spelarens värden samt metoder för att uppdatera spelarens resultat under spelets gång. 

UpdatePoints() uppdaterar spelarens totala poäng. 

UpdateCorrectAnswers() registrerar korrekta svar. 

UpdateCorrectInRow() hanterar spelarens streak av korrekta svar och återställer den vid fel svar. 

Player-klassen används av spelets logik för att hålla reda på spelarens prestation och resultat. 

Branch: feature/HighScore Author: Jonathan Holm 

Branchens mål är att skapa Klassen HighScore med en lista bestående av Player object. 

Metoder i Klassen är tre: 

Skapa/hämta listan: If sats avgör om ny lista skapas när filen inte existerar, annars hämtar den listan genom Jsonserializers deserialize metod. 

Anropas för utskrift i konsolen av listan: Skriver ut listan genom en for loop där längden av loopen avgörs av antal player objekt. 

Uppdatera listan: Tar emot player object och lägger till dom i listan, använder sen order by LINQ uttryck för att lägga i ordning av poäng och behåller de 10 högsta. Därefter används Jsonserializers serialize metod för att förbereda listan för att formattera för json och File.writealltext för att uppdatera json filen. 

feature/question by Rami 

Klasserna ChoiceQuestion och TrueFalseQuestion används för flervalsfrågor och sant-falskt frågor. De innehåller svarsalternativ och information om vilket alternativ som är rätt. Klasserna ärver metoden CheckAnswer() från den abstrakta klassen Quiz. Metoden används för att kontrollera om spelarens svar är korrekt eller inte. Klassen Quiz innehåller även metoden GetPoints(), som hanterar poängsystemet. 

Båda frågeklasserna implementerar också metoden PrintQuestio() från interfacet IQuestion, som ansvarar för att visa frågetexten på skärmen. Metoden implementeras på olika sätt beroende på frågans typ och hur den ska presenteras för spelaren. 

Båda frågeklasserna implementerar också metoden 'PrintQuestion' från interfacet 'IQuestion', som ansvarar för att visa frågetexten på skärmen. Metoden implementeras på olika sätt beroende på frågans typ och hur den ska presenteras för spelaren. 

feature/ GameLogic 

Author: Rami, Jonathan och Bryan. 

Availablelist: 
Används för att spara questions jsonfil objekt. 

Players: Lista av player objekt för nuvarande instans av spelet. 

Roundnumber: Antal rundor som spelats. 

Targetround: Planerad slutrunda. 

Closegame: Boolean som avslutar spelet. 

Filename: Plats för frågefilen. 

Highscore: Används för att updatera highscore listan. 

Gamelogic En konstruktor som skapar ett objekt av gamelogic klassen. 

Startgame: Återställa temporära filer. Kräver namn och antal spelare samt antal rundor. 
Använder createlist för att skapa en frågelista för den nuvarande instansen. Loopar sen genom playround tills targetround är noll. 

Createlist: Läser in frågor från jsonfilen Omvandlar först till sträng sen till objekt med kategorien som egenskap och blandar sedan listan. 

Pickquestion: Hämtar vilka kategorier som finns i available list för att sedan representera dem som val samt random även mäng av kvarvarande frågor. 
Hanter sedan själva valet logiken och returnerar objekt av vald kategori eller slumpad 

Playround: Loopar genom varje spelare i player list som då får välja kategori och svara på sin fråga i turordning. Updaterar sedan player objekt beroende på svar. 

Endgame: Updaterar highscore json och presenterar resultat. 

 

 

 
