# TheCarTolls

- Har skapat en publik GitHub-repository. L�nken �r: https://github.com/RakanEngineer/TheCarTolls
- I koden anv�nds konstanter f�r att representera viktiga v�rden som tr�ngselskattesatser, max total avgift och fria fordonstyper. Genom att anv�nda konstanter blir koden l�ttl�st och m�jligg�r enkel �ndring i framtiden.
- Genom att abstrahera tidsintervallskontrollen till en separat funktion (IsWithinTimeInterval), har jag skapat en �versiktlig och �teranv�ndbar metod f�r att avg�ra om en given tidpunkt befinner sig inom ett visst tidsintervall.
- Jag har f�renklat fl�det i koden genom att ta bort on�diga villkor och anv�nda enklare strukturer f�r att f�rb�ttra l�sbarheten. Exempelvis har jag reviderat villkoren i GetTollFee-metoden f�r att g�ra dem mer �versk�dliga.
- Jag har skrivit n�gra testfall ocks� f�r att t�cka olika situationer, inklusive skattefria dagar och tidpunkter samt en scenarie med maximal totalavgift.
- Det finns n�gra fel p� koden som jag beh�vde ta bort dem.t.ex if (year == 2013), tagit bort, f�r att koden kan fungera bra.
- Objektstruktur: Alla fordon har samma basklass/interface. Jag tycker det borde finnas klasser f�r alla typer, jag saknar Emergency, Diplomat, Foreign och Military klassarna. Jag har bara skapat Tractor-klass och jag kan skapa de andra.
- Det finns s�kert mycket mer man skulle kunna g�ra! och jag ser fram emot eventuell ytterligare feedback eller diskussion!

# TheCarTolls : 19-1-2024

Jag har gjort f�ljande f�rb�ttringar och till�gg:

1. Anv�ndning av Interface (IVehicle): Jag har introducerat ett gr�nssnitt IVehicle f�r fordon och �ndrat metoden GetTollFee i TollCalculator f�r att ta emot ett objekt av typen IVehicle. Detta m�jligg�r anv�ndning av flera olika fordonstyper i st�llet f�r att bara hantera klasser direkt.
2. Nya fordonstyper: Jag har lagt till nya fordonstyper som implementerar IVehicle: Emergency, Diplomat, Foreign, och Military.
3. Ut�kade testfall: Jag har lagt till fler testfall f�r olika fordonstyper och scenarier, inklusive olika tidpunkter, skattefria dagar och skattefria tidpunkter.
4. F�renklad hantering av helgdagar: Jag har inf�rt en separat metod IsTodayHoliday f�r att kolla om en given dag �r en helgdag. Denna metod anv�nder en lista med helgdagar som genereras med hj�lp av GetHolidays-metoden.
5. Refaktorering: Jag har refaktorerat kod f�r att �ka l�sbarheten och underh�llbarheten, inklusive att extrahera gemensamma kodsnuttar till separata metoder.
6. Kommentarer: Jag har lagt till kommentarer som f�rklarar vad varje del av koden g�r och ger exempel p� olika testfall.
7. Jag anv�ndar GetType, typeof f�r metoden GetVehicleType som returnerar en string. Jag tycker det �r lite on�digt att jobba med string, s� jag anv�nder GetType, typeof.
Dessa f�r�ndringar g�r koden mer flexibel, l�ttare att underh�lla och mer utbyggbar med nya fordonstyper eller funktioner i framtiden. Jag har ocks� inkluderat utf�rliga testfall f�r att s�kerst�lla att koden fungerar korrekt i olika scenarier.