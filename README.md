# TheCarTolls

- Har skapat en publik GitHub-repository. Länken är: https://github.com/RakanEngineer/TheCarTolls
- I koden används konstanter för att representera viktiga värden som trängselskattesatser, max total avgift och fria fordonstyper. Genom att använda konstanter blir koden lättläst och möjliggör enkel ändring i framtiden.
- Genom att abstrahera tidsintervallskontrollen till en separat funktion (IsWithinTimeInterval), har jag skapat en översiktlig och återanvändbar metod för att avgöra om en given tidpunkt befinner sig inom ett visst tidsintervall.
- Jag har förenklat flödet i koden genom att ta bort onödiga villkor och använda enklare strukturer för att förbättra läsbarheten. Exempelvis har jag reviderat villkoren i GetTollFee-metoden för att göra dem mer överskådliga.
- Jag har skrivit några testfall också för att täcka olika situationer, inklusive skattefria dagar och tidpunkter samt en scenarie med maximal totalavgift.
- Det finns några fel på koden som jag behövde ta bort dem.t.ex if (year == 2013), tagit bort, för att koden kan fungera bra.
- Objektstruktur: Alla fordon har samma basklass/interface. Jag tycker det borde finnas klasser för alla typer, jag saknar Emergency, Diplomat, Foreign och Military klassarna. Jag har bara skapat Tractor-klass och jag kan skapa de andra.
- Det finns säkert mycket mer man skulle kunna göra! och jag ser fram emot eventuell ytterligare feedback eller diskussion!

# TheCarTolls : 19-1-2024

Jag har gjort följande förbättringar och tillägg:

1. Användning av Interface (IVehicle): Jag har introducerat ett gränssnitt IVehicle för fordon och ändrat metoden GetTollFee i TollCalculator för att ta emot ett objekt av typen IVehicle. Detta möjliggör användning av flera olika fordonstyper i stället för att bara hantera klasser direkt.
2. Nya fordonstyper: Jag har lagt till nya fordonstyper som implementerar IVehicle: Emergency, Diplomat, Foreign, och Military.
3. Utökade testfall: Jag har lagt till fler testfall för olika fordonstyper och scenarier, inklusive olika tidpunkter, skattefria dagar och skattefria tidpunkter.
4. Förenklad hantering av helgdagar: Jag har infört en separat metod IsTodayHoliday för att kolla om en given dag är en helgdag. Denna metod använder en lista med helgdagar som genereras med hjälp av GetHolidays-metoden.
5. Refaktorering: Jag har refaktorerat kod för att öka läsbarheten och underhållbarheten, inklusive att extrahera gemensamma kodsnuttar till separata metoder.
6. Kommentarer: Jag har lagt till kommentarer som förklarar vad varje del av koden gör och ger exempel på olika testfall.
7. Jag användar GetType, typeof för metoden GetVehicleType som returnerar en string. Jag tycker det är lite onödigt att jobba med string, så jag använder GetType, typeof.
Dessa förändringar gör koden mer flexibel, lättare att underhålla och mer utbyggbar med nya fordonstyper eller funktioner i framtiden. Jag har också inkluderat utförliga testfall för att säkerställa att koden fungerar korrekt i olika scenarier.