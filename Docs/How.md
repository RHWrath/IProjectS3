# How

Hoe gaan we het systeem eigenlijk maken?

## Framework

We hebben besloten om SolidJS te gaan gebruiken. Dit framework lijkt erg veel op React, maar is iets makkelijker in gebruik. We gebruiken SolidUI als component library. Dit bespaart ons veel tijd met het maken van de UI.

## Backend

De backend wordt geschreven in C#. We hebben hier allemaal ervaring mee, dus dit werkt het makkelijkste samen. Ook is het erg makkelijk om een api met OpenAPI ondersteuning te maken in C# omdat dit ingebouwd is in de taal.

## Repo setup

We gebruiken een monorepo met mapjes per service of frontend. Hierdoor kunnen we makkelijk samenwerken, en is het uiteindelijk ook makkelijker om de hele applicatie online te krijgen.
