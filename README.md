# SP-Trivia Gruppexamination: Quiz Battle
Branch feature/Player 

Author Bryan 

Player-klassen representerar en spelare i Quiz Battle och ansvarar för att lagra spelarens namn, poäng antal korrekta svar, svarsstreak samt datum och tid då spelarobjektet skapades. Klassen innehåller en konstruktor som initierar spelarens värden samt metoder för att uppdatera spelarens resultat under spelets gång. 

UpdatePoints() uppdaterar spelarens totala poäng.

UpdateCorrectAnswers() registrerar korrekta svar.

UpdateCorrectInRow() hanterar spelarens streak av korrekta svar och återställer den vid fel svar.

Player-klassen används av spelets logik för att hålla reda på spelarens prestation och resultat. 

Branch: feature/HighScore 
Author: Jonathan Holm 
Branchens mål är att skapa Klassen HighScore med en lista bestående av Player object. 

Metoder i Klassen är tre:

Skapa/hämta listan:
If sats avgör om ny lista skapas när filen inte existerar, annars hämtar den listan genom Jsonserializers deserialize metod. 

Anropas för  utskrift i konsolen av listan:
Skriver ut listan genom en for loop där längden av loopen avgörs av antal player objekt. 

Uppdatera listan:
Tar emot player object och lägger till dom i listan, använder sen order by LINQ uttryck för att lägga i ordning av poäng och behåller de 10 högsta. Därefter används Jsonserializers serialize metod för att förbereda listan för att formattera för json och File.writealltext för att uppdatera json filen. 


### feature/GameLogic by Rami

klassen GameLogic ansvarar bland annat för att starta ett nytt spel, ta emot information från spelarna och hålla reda på rundorna. När spelet startar får användarna ange hur många spelare som ska delta, spelarnas namn och hur många rundor de vill spela. Den kontroller och säkerställer att antalet spelare är mellan 2 och 4, att namnen inte är tomma eller lika och att antalet rundor är mellan 1 och 10.

Metoden PlayRound() i klassen GameLogic används för att låta spelarna svara på frågor i tur och ordning. Varje spelare får välja en kategori och därefter visas en fråga. När spelaren har svarat kontrolleras svaret och spelaren får poäng om svaret är rätt.

EndGame() visar slutresultatet och bestämmer vem som vinner. Spelarna sorteras efter sina poäng. Om flera spelare har samma poäng jämförs även antalet rätta svar. Om båda värdena är lika delar spelarna på segern. Resultaten skickas också vidare till klassen HighScore för att visa Topplistan som visar de tio bästa resultaten genom tiderna
