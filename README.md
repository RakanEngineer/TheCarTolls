# TheCarTolls

- Har skapat en publik GitHub-repository. L�nken �r: https://github.com/RakanEngineer/TheCarTolls
- I koden anv�nds konstanter f�r att representera viktiga v�rden som tr�ngselskattesatser, max total avgift och fria fordonstyper. Genom att anv�nda konstanter blir koden l�ttl�st och m�jligg�r enkel �ndring i framtiden.
- Genom att abstrahera tidsintervallskontrollen till en separat funktion (IsWithinTimeInterval), har jag skapat en �versiktlig och �teranv�ndbar metod f�r att avg�ra om en given tidpunkt befinner sig inom ett visst tidsintervall.
- Jag har f�renklat fl�det i koden genom att ta bort on�diga villkor och anv�nda enklare strukturer f�r att f�rb�ttra l�sbarheten. Exempelvis har jag reviderat villkoren i GetTollFee-metoden f�r att g�ra dem mer �versk�dliga.
- Jag har skrivit n�gra testfall ocks� f�r att t�cka olika situationer, inklusive skattefria dagar och tidpunkter samt en scenarie med maximal totalavgift.
- Det finns n�gra fel p� koden som jag beh�vde ta bort dem.t.ex if (year == 2013), tagit bort, f�r att koden kan fungera bra.
- Objektstruktur: Alla fordon har samma basklass/interface. Jag tycker det borde finnas klasser f�r alla typer, jag saknar Emergency, Diplomat, Foreign och Military klassarna. Jag har bara skapat Tractor-klass och jag kan skapa de andra.
- Det finns s�kert mycket mer man skulle kunna g�ra! och jag ser fram emot eventuell ytterligare feedback eller diskussion!