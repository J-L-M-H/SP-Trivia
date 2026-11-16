# SP-Trivia
## Grupp-projekt objektorienterad programmering

### feature/question by Rami

Klasserna ChoiceQuestion och TrueFalseQuestion används för flervalsfrågor och sant-falskt frågor. De innehåller svarsalternativ och information om vilket alternativ som är rätt. Klasserna ärver metoden CheckAnswer() från den abstrakta klassen Quiz. Metoden används för att kontrollera om spelarens svar är korrekt eller inte. Klassen Quiz innehåller även metoden GetPoints(), som hanterar poängsystemet.

Båda frågeklasserna implementerar också metoden PrintQuestio() från interfacet IQuestion, som ansvarar för att visa frågetexten på skärmen. Metoden implementeras på olika sätt beroende på frågans typ och hur den ska presenteras för spelaren.

Båda frågeklasserna implementerar också metoden 'PrintQuestion' från interfacet 'IQuestion', som ansvarar för att visa frågetexten på skärmen. Metoden implementeras på olika sätt beroende på frågans typ och hur den ska presenteras för spelaren.
