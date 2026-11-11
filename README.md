# SP-Trivia Gruppexamination: Quiz Battle
Branch feature/Player 

Author Bryan 

Player-klassen representerar en spelare i Quiz Battle och ansvarar för att lagra spelarens namn, poäng antal korrekta svar, svarsstreak samt datum och tid då spelarobjektet skapades. Klassen innehåller en konstruktor som initierar spelarens värden samt metoder för att uppdatera spelarens resultat under spelets gång. 

UpdatePoints() uppdaterar spelarens totala poäng.

UpdateCorrectAnswers() registrerar korrekta svar.

UpdateCorrectInRow() hanterar spelarens streak av korrekta svar och återställer den vid fel svar.

Player-klassen används av spelets logik för att hålla reda på spelarens prestation och resultat. 
