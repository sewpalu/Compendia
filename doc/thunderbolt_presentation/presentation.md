---
marp: true
theme: uncover
class: invert
_class:
    - lead
    - invert
paginate: true
_paginate: false
---

<style>

section.animated_background
{
    animation-name: cycleColourGrad;
    animation-duration: 20s;
    animation-iteration-count: infinite;
    background-image: linear-gradient(0deg, rgb(148, 20, 124), rgb(93, 90,210), rgb(148, 20, 124), rgb(93, 90, 210));
    background-size: 100% 300%;
}

section.diagram ul
{
    list-style-type: none;
    height: 90%;
    padding-left: 0;
    padding-bottom: 1em;
    width: 100%;
}

section.diagram li
{
    padding: 0.5em;
    margin: 0.5em;
}

section.block_diagram li
{
    border-radius: 0.5em;
    height: calc(100% / 4 - 1.5em);
    background-color: rgba(255, 1, 1, 0.5);
}

@keyframes cycleColourBorderLeft
{
    from { border-left-color: rgba(148, 20, 124, 0.5); }
    50% { border-left-color: rgba(93, 90, 210, 0.5); }
    to { border-left-color: rgba(148, 20, 124, 0.5); }
}

@keyframes cycleColour
{
    from { background-color: rgba(148, 20, 124, 0.5); }
    50% { background-color: rgba(93, 90, 210, 0.5); }
    to { background-color: rgba(148, 20, 124, 0.5); }
}

@keyframes cycleColourGrad
{
    from { background-position: 100% 100%; }
    to {background-position: 0% 0%; }
}

section.block_diagram li:nth-child(1)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -0s;
    animation-iteration-count: infinite;
}

section.block_diagram li:nth-child(2)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -1s;
    animation-iteration-count: infinite;
}

section.block_diagram li:nth-child(3)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -2s;
    animation-iteration-count: infinite;
}

section.block_diagram li:nth-child(4)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -3s;
    animation-iteration-count: infinite;
}

section.block_diagram li:nth-child(5)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -4s;
    animation-iteration-count: infinite;
}

section.block_diagram li:nth-child(6)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -5s;
    animation-iteration-count: infinite;
}

section.block_diagram li:nth-child(7)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -6s;
    animation-iteration-count: infinite;
}

section.block_diagram li:nth-child(8)
{
    animation-name: cycleColour;
    animation-duration: 8s;
    animation-delay: -7s;
    animation-iteration-count: infinite;
}

/* one item */
section.block_diagram li:first-child:nth-last-child(1)
{
/* -or- li:only-child { */
    height: calc(100% / 1 - 1.5em);
}

/* two items */
section.block_diagram li:first-child:nth-last-child(2),
section.block_diagram li:first-child:nth-last-child(2) ~ li
{
    height: calc(100% / 2 - 1.5em);
}

/* three items */
section.block_diagram li:first-child:nth-last-child(3),
section.block_diagram li:first-child:nth-last-child(3) ~ li
{
    height: calc(100% / 3 - 1.5em);
}

/* four items */
section.block_diagram li:first-child:nth-last-child(4),
section.block_diagram li:first-child:nth-last-child(4) ~ li
{
    height: calc(100% / 4 - 1.5em);
}

/* five items */
section.block_diagram li:first-child:nth-last-child(5),
section.block_diagram li:first-child:nth-last-child(5) ~ li
{
    height: calc(100% / 5 - 1.5em);
}

/* six items */
section.block_diagram li:first-child:nth-last-child(6),
section.block_diagram li:first-child:nth-last-child(6) ~ li
{
    padding-top: 0.2em;
    padding-bottom: 0.3em;
    height: calc(100% / 6 - 1em);
}

/* seven items */
section.block_diagram li:first-child:nth-last-child(7),
section.block_diagram li:first-child:nth-last-child(7) ~ li
{
    height: calc(100% / 7 - 0.5em);
    padding-top: 0em;
    padding-bottom: 0em;
}

/* eight items */
section.block_diagram li:first-child:nth-last-child(8),
section.block_diagram li:first-child:nth-last-child(8) ~ li
{
    padding-top: 0em;
    padding-bottom: 0em;
    height: calc(100% / 8 - 0.5em);
}

section.trapezoid_diagram li
{
    --base_width: 115vh;
    position: absolute;
    width: var(--width);
    height: 70%;
    top: 20%;
    padding-top: 1.5em;
    --left: 0;
    left: var(--left);
}

section.trapezoid_diagram li::before
{
    --base_width: 115vh;
    content: "";
    --width: 200px;
    border-left: var(--width) solid red;
    border-bottom: 2em solid transparent;
    border-top: 2em solid transparent;
    width: var(--width);
    height: 60%;
    position: absolute;
    top: 0;
    z-index: -1;
    left: 0;
    animation-name: cycleColourBorderLeft;
    animation-duration: 8s;
    animation-iteration-count: infinite;
}

li:nth-child(2), li:nth-child(2)::before
{
    --left: calc(var(--width) + 0.5em);
    animation-delay: -1s;
}

li:nth-child(3), li:nth-child(3)::before
{
    --left: calc((var(--width) + 0.5em) * 2);
    animation-delay: -2s;
}

li:nth-child(4), li:nth-child(4)::before
{
    --left: calc((var(--width) + 0.5em) * 3);
    animation-delay: -3s;
}

section.trapezoid_diagram li:first-child:nth-last-child(1),
section.trapezoid_diagram li:first-child:nth-last-child(1)::before
{
    --width: calc(var(--base_width) - 0.5em);
}

section.trapezoid_diagram li:first-child:nth-last-child(2),
section.trapezoid_diagram li:first-child:nth-last-child(2) ~ li,
section.trapezoid_diagram li:first-child:nth-last-child(2)::before,
section.trapezoid_diagram li:first-child:nth-last-child(2) ~ li::before
{
    --width: calc(var(--base_width) / 2 - 0.5em);
}

section.trapezoid_diagram li:first-child:nth-last-child(3),
section.trapezoid_diagram li:first-child:nth-last-child(3) ~ li,
section.trapezoid_diagram li:first-child:nth-last-child(3)::before,
section.trapezoid_diagram li:first-child:nth-last-child(3) ~ li::before
{
    --width: calc(var(--base_width) / 3 - 0.5em);
}

section.trapezoid_diagram li:first-child:nth-last-child(4),
section.trapezoid_diagram li:first-child:nth-last-child(4) ~ li,
section.trapezoid_diagram li:first-child:nth-last-child(4)::before,
section.trapezoid_diagram li:first-child:nth-last-child(4) ~ li::before
{
    --width: calc(var(--base_width) / 4 - 0.5em);
}

</style>

<!-- _backgroundImage: url("lightning.jpg") -->

# Thunderbolt
## und Ausblick auf USB 4

---

<!-- class: invert diagram trapezoid_diagram -->

## Test 1

- 1

---

## Test 2

- 1
- 2

---

## Test 3

- 1
- 2
- 3

---

## Test 4

- 1
- 2
- 3
- 4

---

<!-- class: invert diagram block_diagram -->

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

<!-- _class: invert diagram trapezoid_diagram -->

## Thunderbolt 2
- 2013 vorgestellt
- 20 GBit/s
- Flexibel nutzbare Bandbreite

---

<!-- _class: invert diagram trapezoid_diagram -->

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
