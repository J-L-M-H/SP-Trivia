# SP-Trivia
## Grupp-projekt objektorienterad programmering

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
