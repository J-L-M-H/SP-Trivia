# SP-Trivia
## Grupp-projekt objektorienterad programmering

### feature/question by Rami

Jag hade ansvar för att skapa frågorna, visa dem på skärmen samt kontrollera om spelaren svarade rätt eller fel. Jag delade in frågorna i två kategorier: sant- eller falskt-frågor och textfrågor. För att hantera dessa skapade jag klasserna 'ChoiceQuestion' och 'TrueFalseQuestion', som ärver metoden 'CheckAnswer' från den abstrakta klassen 'Quiz'. Metoden används för att kontrollera om spelarens svar är korrekt eller inte. Klassen 'Quiz' innehåller även metoden 'GetPoints', som hanterar poängsystemet.

Båda frågeklasserna implementerar också metoden 'PrintQuestion' från interfacet 'IQuestion', som ansvarar för att visa frågetexten på skärmen. Metoden implementeras på olika sätt beroende på frågans typ och hur den ska presenteras för spelaren.
