# Anforderungen

| ID  | Autor(en)             | Version | Beschreibung                                      |
| --- | --------------------- | ------- | ------------------------------------------------- |
| 0   | Lisa, Oliver, Patrick | 1.0     | Hilfefunktion                                     |
| 1   | Lisa, Oliver, Patrick | 1.0     | Datenabfrage                                      |
| 2   | Lisa, Oliver, Patrick | 1.0     | Eintrag verändern                                 |
| 3   | Lisa, Oliver, Patrick | 1.0     | Eintrag löschen                                   |
| 4   | Lisa, Oliver, Patrick | 1.0     | Eintrag erstellen                                 |
| 5   | Lisa, Oliver, Patrick | 1.0     | Datensynchronisation                              |
| 6   | Lisa, Oliver, Patrick | 1.0     | App beenden                                       |
| 7   | Lisa, Oliver, Patrick | 1.0     | Kalender einsehen                                 |
| 8   | Lisa, Oliver, Patrick | 1.0     | Tagesansicht                                      |
| 9   | Lisa, Oliver, Patrick | 1.0     | Monatsansicht                                     |
| 10  | Lisa, Oliver, Patrick | 1.0     | Ansicht aller Einträge                            |
| 11  | Lisa, Oliver, Patrick | 1.0     | Datum anzeigen                                    |
| 12  | Lisa, Oliver, Patrick | 1.0     | Datumseingabe                                     |
| 13  | Lisa, Oliver, Patrick | 1.0     | Benutzerspezifische Datenspeicherung              |
| 14  | Lisa, Oliver, Patrick | 1.0     | Sign Up                                           |
| 15  | Lisa, Oliver, Patrick | 1.0     | Sign In                                           |
| 16  | Lisa, Oliver, Patrick | 1.0     | Graphisches Userinterface                         |
| 17  | Lisa, Oliver, Patrick | 1.0     | App                                               |
| 18  | Lisa, Oliver, Patrick | 1.0     | Benachrichtigung bei Unverfügbarkeit des Servers  |
| 19  | Lisa, Oliver, Patrick | 1.0     | Übersichtliche Darstellung                        |
| 20  | Lisa, Oliver, Patrick | 1.0     | Log Out                                           |

## Szenario: Sign In

| Abschnitt        | Inhalt                                                                                                                                                                                                  |
| ---------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Bezeichner       | S-15                                                                                                                                                                                                    |
| Name             | Einloggen in die App                                                                                                                                                                                    |
| Autor(en)        | Lisa, Oliver, Patrick                                                                                                                                                                                   |
| Version          | 1.0                                                                                                                                                                                                     |
| Priorität        | Hoch                                                                                                                                                                                                    |
| Kurzbeschreibung | Benutzer kann sich mit Benutzername und Passwort erfolgreich anmelden                                                                                                                                   |
| Akteur(e)        | Benutzer                                                                                                                                                                                                |
| Vorbedingung     | <ul><li>Benutzer verfügt über Logindaten <li>Benutzer besitzt aktivierten Compendia-Account <li> App wurde gestartet </ul>                                                                              |
| Nachbedingung    | Startseite öffnet sich                                                                                                                                                                                  |
| Ergebnis         | Benutzer ist in der Compendia-App eingeloggt                                                                                                                                                            |
| Szenarioschritte | <ol><li>Benutzer gibt Benutzername ein <li>Benutzer gibt Passwort ein <li>Benutzername wird überprüft <li>Passwort wird überprüft <li>Bei Fehlern wird eine entsprechende Fehlermeldung angezeigt </ol> |

## Use-Case

![Diagramm: Use-Case Eintrag hinzufügen](use-case_eintrag_hinzufuegen.svg)

