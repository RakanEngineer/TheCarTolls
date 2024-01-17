# TheCarTolls

- Har skapat en publik GitHub-repository. Länken är: https://github.com/RakanEngineer/TheCarTolls
- I koden används konstanter för att representera viktiga värden som trängselskattesatser, max total avgift och fria fordonstyper. Genom att använda konstanter blir koden lättläst och möjliggör enkel ändring i framtiden.
- Genom att abstrahera tidsintervallskontrollen till en separat funktion (IsWithinTimeInterval), har jag skapat en översiktlig och återanvändbar metod för att avgöra om en given tidpunkt befinner sig inom ett visst tidsintervall.
- Jag har förenklat flödet i koden genom att ta bort onödiga villkor och använda enklare strukturer för att förbättra läsbarheten. Exempelvis har jag reviderat villkoren i GetTollFee-metoden för att göra dem mer överskådliga.
- Jag har skrivit några testfall också för att täcka olika situationer, inklusive skattefria dagar och tidpunkter samt en scenarie med maximal totalavgift.
- Det finns några fel på koden som jag behövde ta bort dem.t.ex if (year == 2013), tagit bort, för att koden kan fungera bra.
- Objektstruktur: Alla fordon har samma basklass/interface. Jag tycker det borde finnas klasser för alla typer, jag saknar Emergency, Diplomat, Foreign och Military klassarna. Jag har bara skapat Tractor-klass och jag kan skapa de andra.
- Det finns säkert mycket mer man skulle kunna göra! och jag ser fram emot eventuell ytterligare feedback eller diskussion!