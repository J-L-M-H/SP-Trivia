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
Klasserna ChoiceQuestion och TrueFalseQuestion används för flervalsfrågor och sant-falskt frågor. De innehåller svarsalternativ och information om vilket alternativ som är rätt. Klasserna ärver metoden CheckAnswer() från den abstrakta klassen Quiz. Metoden används för att kontrollera om spelarens svar är korrekt eller inte. Klassen Quiz innehåller även metoden GetPoints(), som hanterar poängsystemet.

Båda frågeklasserna implementerar också metoden PrintQuestio() från interfacet IQuestion, som ansvarar för att visa frågetexten på skärmen. Metoden implementeras på olika sätt beroende på frågans typ och hur den ska presenteras för spelaren.

Båda frågeklasserna implementerar också metoden 'PrintQuestion' från interfacet 'IQuestion', som ansvarar för att visa frågetexten på skärmen. Metoden implementeras på olika sätt beroende på frågans typ och hur den ska presenteras för spelaren.


### feature/ GameLogic 
Author: Rami, Jonathan och Bryan. 
 
Availablelist:  
Används för att spara questions jsonfil objekt. 
 
Players: 
Lista av player objekt för nuvarande instans av spelet.  
 
Roundnumber: 
Antal rundor som spelats. 
 
Targetround: 
Planerad slutrunda.  
 
Closegame: 
Boolean som avslutar spelet.  
 
Filename: 
Plats för frågefilen.  
 
Highscore: 
Används för att updatera highscore listan. 
 
Gamelogic 
En konstruktor som skapar ett objekt av gamelogic klassen.  
 
Startgame: 
Återställa temporära filer. 
Kräver namn och antal spelare samt antal rundor.  
Använder createlist för att skapa en frågelista för den nuvarande instansen. 
Loopar sen genom playround tills targetround är noll.   

 

Createlist: 
Läser in frågor från jsonfilen 
Omvandlar först till sträng sen till objekt med kategorien som egenskap och blandar sedan listan. 
 
Pickquestion: 
Hämtar vilka kategorier som finns i available list för att sedan representera dem som val samt random även mäng av kvarvarande frågor.  
Hanter sedan själva valet logiken och returnerar objekt av vald kategori eller slumpad  
 
Playround: 
Loopar genom varje spelare i player list som då får välja kategori och svara på sin fråga i turordning. 
Updaterar sedan player objekt beroende på svar.  
 
Endgame: 
Updaterar highscore json och presenterar resultat.  
 
 
