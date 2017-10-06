# story-generator

Story Generator is a REST API which can be used to generate a random plot for the Type Moon’s “Fate” series. 

### Contents
* [Introduction](#introduction)<br/>
* [Functional Overview](#functionalOverview)<br/>
* [How to use it](#howToUseIt)<br/>
* [How to add mages](#howToAddMages)<br/>
* [How to add servants](#howToAddServants)<br/>
* [Installation Notes](#installationNotes)<br/>
* [Disclaimer](#disclaimer)<br/>

<a name="introduction"/>

### Introduction

The Fate series is a novel/manga/anime franchise. The stories in this series follow a simple premise:
* Once every few generations, the Holy Grail appears
* Seven mages (people with magical abilities) are chosen to fight for the Grail
* This battle is called the “Grail War”
* Each mage summons a mythical hero to help them fight
* A mage’s hero is referred to as the mage’s servant
* The last mage standing wins
* The winner is granted one wish by the Grail

This API randomly selects seven mages who each summon a hero, and creates a randomly generated description of how the Grail War unfolds. 
There are two primary purposes to this project:
* To practice and display my abilities as a C#, ASP.NET Core developer
* Fun! ^__^

<a name="functionalOverview"/>

### Functional Overview

The functionality of the project is exposed using a REST API. Behind the scenes, it uses ASP.NET Core’s MVC framework and is written in C#. It uses RavenDB to store its data. 
To generate a plot, seven mages are randomly selected. Each mage is randomly assigned a hero. From that point onward, events are iteratively selected at random. These events include:
* The forming/breaking of alliances between mages
* Battles between two mages
The outcomes of these events are random, but may be affected by the attributes of the mages and their servants. For example, powerful mages and servants are more likely to defeat weaker mages and servants.
It will continue to iteratively select these events until only one mage remains in the war. At this point, the war ends and the remaining mage wins the grail.

<a name="howToUseIt"/>

### How to use it

This project is a work-in-progress, but this section describes how it will work once completed.
Story Generator is an API only – it has no user interface. To generate a plot, we must make a call to the API using the following URI template:


``
<YOUR_DOMAIN>/api/grailWar/start
``

The plot will be generated and sent back to the caller in JSON format. It will look something like the following:

```
[
“The Holy Grail has appeared”,
“Emiya Kiritsugu, Kotomine Kirei, Tokiomi Tohsaka, Kariya Matou, Kayneth Archibald, Ryunosuke Uryu and Waver Velvet have been chosen for the Grail War”,
“Emiya Kiritsugu summons Hercules as Berserker”,
“Kotomine Kirei summons Gilgamesh as Archer”,
.........
.........
.........
“Kiritsugu and Hercules ambush Tokiomi”,
 “With only two mages left, this will be the final battle”,
“After a close battle, Hercules is defeated by Saber”,
“Kiritsugu escapes and takes shelter at the church”,
“With all opposition defeated, Tokiomi and Saber win the Grail”
]
```

<a name="howToAddMages"/>

### How to add mages

Mages can be added by the database by making a POST HTTP request to the API. I personally use Postman to make such requests. The body of the request must contain the details of the mage in JSON format. The following example can be used as a template for creating new mages:

```javascript
{
"name": "Kotomine Kirei",
"strength": 87,
"magic": 83,
"fightingAbility": 87,
"strategicAbility": 90,
"violence": 88,
"arogance": 86,
"selfishness": 94,
"honour": 18,
"kindness": 17,
"mercifulness": 24
}
```

A mage’s attributes will determine the likelihood of that mage creating an alliance with other mages. A mage’s attributes combined with the attributes of their servant will determine the likelihood of that mage defeating an opponent mage and servant.

<a name="howToAddServants"/>

### How to add servants

Similarly, servants can be added by the database by making a POST HTTP request to the API. The body of the request must contain the details of the servant in JSON format. The following example can be used as a template for creating new mages:

```javascript
{
"name": "Iskandar",
"servantClass": "Rider",
"noblePhantasm": {
  "name": "Chariot",
  "power": 123
},
"strength": 85,
"magic": 68,
"fightingAbility": 86,
"strategicAbility": 71
}
```

A Noble Phantasm refers to the servant’s mythical weapon.

<a name="installationNotes"/>

### Installation notes

Considering that this project doesn’t really serve any practical purpose and is purely for fun, it’s probably unlikely that anyone will ever install this.
 However, on the off chance that someone does, you should note that you must also install and run an instance of RavenDb. The project is configured to connect to RavenDb via the localhost on port 8080. You must create a database called “GrailWarDB”. You will not be able to generate a story until you have created at least seven mages and seven servants in the database. 

<a name="disclaimer"/>

### Disclaimer

I am a tech enthusiast and a fan of the Fate series. This project is a combination of those two aspects of my personality. It is intended to be used purely for fun. I claim no ownership over any of the characters, stories or intellectual properties associated with the Fate series. There is, and should never be any money or profit associated with this project. 

