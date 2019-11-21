---
marp: true
theme: uncover
class: invert
_class:
    - lead
    - invert
---

<style>
ul{
    list-style-type: none;
    height: 90%;
    padding-left: 0;
    padding-bottom: 1em;
    width: 100%;
}

li{
    border-radius: 0.5em;
    height: calc(100% / 4 - 1.5em);
    padding: 0.5em;
    margin: 0.5em;
    background-color: rgba(255, 1, 1, 0.5);
}

@keyframes cycleColour{
    from { background-color: rgba(148, 20, 124, 0.5); }
    50% { background-color: rgba(93, 90, 210, 0.5); }
    to { background-color: rgba(148, 20, 124, 0.5); }
}

body
{
    animation-name: cycleColour;
    animation-duration: 4s;
    animation-iteration-count: infinite;
}


li:nth-child(1)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -0s;
    animation-iteration-count: infinite;
}

li:nth-child(2)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -1s;
    animation-iteration-count: infinite;
}

li:nth-child(3)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -2s;
    animation-iteration-count: infinite;
}

li:nth-child(4)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -3s;
    animation-iteration-count: infinite;
}

li:nth-child(5)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -4s;
    animation-iteration-count: infinite;
}

li:nth-child(6)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -5s;
    animation-iteration-count: infinite;
}

li:nth-child(7)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -6s;
    animation-iteration-count: infinite;
}

li:nth-child(8)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -7s;
    animation-iteration-count: infinite;
}

/* one item */
li:first-child:nth-last-child(1) {
/* -or- li:only-child { */
    height: calc(100% / 1 - 1.5em);
}

/* two items */
li:first-child:nth-last-child(2),
li:first-child:nth-last-child(2) ~ li {
    height: calc(100% / 2 - 1.5em);
}

/* three items */
li:first-child:nth-last-child(3),
li:first-child:nth-last-child(3) ~ li {
    height: calc(100% / 3 - 1.5em);
}

/* four items */
li:first-child:nth-last-child(4),
li:first-child:nth-last-child(4) ~ li {
    height: calc(100% / 4 - 1.5em);
}

/* five items */
li:first-child:nth-last-child(5),
li:first-child:nth-last-child(5) ~ li {
    height: calc(100% / 5 - 1.5em);
}

/* six items */
li:first-child:nth-last-child(6),
li:first-child:nth-last-child(6) ~ li {
    padding-top: 0.2em;
    padding-bottom: 0.3em;
    height: calc(100% / 6 - 1em);
}

/* seven items */
li:first-child:nth-last-child(7),
li:first-child:nth-last-child(7) ~ li {
    height: calc(100% / 7 - 0.5em);
    padding-top: 0em;
    padding-bottom: 0em;
}

/* eight items */
li:first-child:nth-last-child(8),
li:first-child:nth-last-child(8) ~ li {
    padding-top: 0em;
    padding-bottom: 0em;
    height: calc(100% / 8 - 0.5em);
}

.animate{
    animation-name: cycleBrightness;
    animation-duration: 1s;
}

</style>

<!-- _backgroundImage: url("lightning.jpg") -->

# Thunderbolt
## und Ausblick auf USB 4

---

## Allgemein

- Von Intel, in Kollaboration mit Apple entwickelt
- Kombination aus DisplayPort und PCI Express
- Universelle Schnittstelle
- 2009 intern, 2011 offiziell vorgestellt
- Kupferkabel, mit optischen Leitern kompatibel
- Benötigt Zusatzchip auf Motherboard

---

## Thunderbolt 1

- Abwärtskompatibel zu DisplayPort
- Mehrere bidirektionale, parallele Kanäle
- Serielle Datenübertragung
- 10 GBit/s
- Unterstützt verschiedene Protokolle gleichzeitig
- Bis zu 3m Kabellänge (optisch 10m)
- Doppelt so schnell wie USB 3.0

---

## Thunderbolt 2
- 2013 vorgestellt
- 20 GBit/s
- Flexibel nutzbare Bandbreite

---

## Thunderbolt 3

- 2015 vorgestellt
- Drehbarer USB-C Stecker
- Universelle Übertragung

---

## USB 4
- Thunderbolttechnologie an USB-IF übergeben
- USB-IF will es für USB 4 nutzen
- Wollen bis 40 GBit/s kommen
- Stecker: USB-C
- Soll 2020 rauskommen
