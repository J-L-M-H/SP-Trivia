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


### feature/question by Rami

Jag hade ansvar för att skapa frågorna, visa dem på skärmen samt kontrollera om spelaren svarade rätt eller fel. Jag delade in frågorna i två kategorier: sant- eller falskt-frågor och textfrågor. För att hantera dessa skapade jag klasserna 'ChoiceQuestion' och 'TrueFalseQuestion', som ärver metoden 'CheckAnswer' från den abstrakta klassen 'Quiz'. Metoden används för att kontrollera om spelarens svar är korrekt eller inte. Klassen 'Quiz' innehåller även metoden 'GetPoints', som hanterar poängsystemet.

Båda frågeklasserna implementerar också metoden 'PrintQuestion' från interfacet 'IQuestion', som ansvarar för att visa frågetexten på skärmen. Metoden implementeras på olika sätt beroende på frågans typ och hur den ska presenteras för spelaren.
