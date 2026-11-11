# SP-Trivia
Grupp-projekt objektorienterad programmering

Branch: feature/HighScore 

Branchens mål är att skapa Klassen HighScore med en lista bestående av Player object. 

Metoder i Klassen är tre:

Skapa/hämta listan:
If sats avgör om ny lista skapas när filen inte existerar, annars hämtar den listan genom Jsonserializers deserialize metod. 

Anropas för  utskrift i konsolen av listan:
Skriver ut listan genom en for loop där längden av loopen avgörs av antal player objekt. 

Uppdatera listan:
Tar emot player object och lägger till dom i listan, använder sen order by LINQ uttryck för att lägga i ordning av poäng och behåller de 10 högsta. Därefter används Jsonserializers serialize metod för att förbereda listan för att formattera för json och File.writealltext för att uppdatera json filen. 

Author: Jonathan Holm 