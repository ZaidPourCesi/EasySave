# EasySave

Présentation Prosoft
Votre équipe vient d'intégrer l'éditeur de logiciels ProSoft. Sous la responsabilité du DSI, vous aurez la responsabilité de gérer le projet “EasySave” qui consiste à développer un logiciel de sauvegarde.

Comme tout logiciel de la Suite ProSoft, le logiciel s'intégrera à la politique tarifaire.
•	Prix unitaire : 200 €HT
•	Contrat de maintenance annuel 5/7 8-17h (mises à jour incluses): 12% prix d'achat (Contrat annuel à tacite reconduction avec revalorisation basée sur l'indice SYNTEC)

Lors de ce projet, votre équipe devra assurer le développement, la gestion des versions majeures et mineures, mais aussi les documentations
•	pour les utilisateurs : manuel d'utilisation (sur une page )
•	pour le support client : Informations nécessaires pour le support technique (Emplacement par défaut du logiciel, Configuration minimale,Emplacement des fichiers de configuration, ....)

Pour garantir une reprise de votre travail par d'autres équipes, la direction vous impose de travailler dans le respect des contraintes suivantes :
•	Outils et méthodes
o	Visual Studio 2019 16.3 ou supérieure
o	GIT Azur DevOps.
o	Editeur UML : Nous préconisations l'utilisation de ArgoUML
« Tous vos documents et l'ensemble des codes doivent être gérés dans ces outils. »
« Votre responsable (tuteur ou pilote) doit être invité sur votre GIT pour pouvoir suivre vos développements »
•	Langage, FrameWork
o	Langage C#
o	Bibliothèque Net.Core 3.X
•	Lisibilité et maintenabilité du code :
o	L'ensemble des documents, lignes de codes et commentaires doivent être exploitables par les filiales anglophones.
o	Le nombre de lignes de code dans une fonction doit être raisonnable
o	La redondance des lignes de code et à proscrire (une vigilance particulière sera faite sur les copier-coller)
o	Respect des conventions de nommage
•	Autres :
o	La documentation utilisateur doit tenir en une seule page
o	Release note obligatoire
Vous devez conduire ce projet de manière à réduire les coûts de développement des futures versions et surtout d'être capable de réagir rapidement à la remontée éventuelle d'un dysfonctionnement.
•	Gestion des versions
•	Limiter au maximum les lignes de code dupliquées
Le logiciel devant être distribué chez les clients, il est impératif de soigner les IHM.
 
 
VERSION 0 : Environnement de travail
Votre équipe doit installer un environnement de travail respectant les contraintes imposées par ProSoft.
Le bon usage de l'environnement de travail et des contraintes imposées par la direction seront évalués tout au long du projet.
Une vigilance particulière sera portée sur :
•	la gestion de GIT (versioning)
•	les diagrammes UML à rendre 24 heures avant chaque livrable (Jalon)
•	La qualité du code (absence de redondance dans les lignes de code)
 
 
VERSION 1 : EasySave version 1.0
Le cahier des charges de la première version du logiciel est le suivant :
•	Le logiciel est une application Console utilisant .Net Core.
•	Le logiciel doit permettre de créer jusqu'à 5 travaux de sauvegarde
•	Un travail de sauvegarde est défini par
o	Une appellation
o	Un répertoire source
o	Un répertoire cible
o	Un type (complet, différentiel)
•	Le logiciel doit être utilisable à minima par des utilisateurs anglophones et Francophones
•	L'utilisateur peut demander l'exécution d'un des travaux de sauvegarde ou l'exécution séquentielle de l'ensemble des travaux.
•	Les répertoires (sources et cibles) pourront être sur :
o	Des disques locaux
o	Des disques Externes
o	Des Lecteurs réseaux
•	Tous les éléments du répertoire source sont concernés par la sauvegarde
•	Fichier Log journalier :
Le logiciel doit écrire en temps réel dans un fichier log journalier l'historique des actions des travaux de sauvegarde. Les informations minimales attendues sont :
o	Horodatage
o	Appellation du travail de sauvegarde
o	Adresse complète du fichier Source (format UNC)
o	Adresse complète du fichier de destination (format UNC)
o	Taille du fichier
o	Temps de transfert du fichier en ms (négatif si erreur)
o	Exemple de contenu: Sample_log.pdf [pdf]
•	Le logiciel doit enregistrer en temps réel, dans un fichier unique, l'état d'avancement des travaux de sauvegarde. Les informations à enregistrer pour chaque travail de sauvegarde sont :
o	Appellation du travail de sauvegarde
o	Horodatage
o	Etat du travail de Sauvegarde (ex : Actif, Non Actif...)
Si le travail est actif :
o	Le nombre total de fichiers éligibles
o	La taille des fichiers à transférer
o	La progression
	Nombre de fichiers restants
	Taille des fichiers restants
	Adresse complète du fichier Source en cours de sauvegarde
	Adresse complète du fichier de destination
o	exemple de contenu : Sample_state.pdf [pdf]
•	Les emplacements des deux fichiers (log journalier et état) devront être étudiés pour fonctionner sur les serveurs des clients. De ce fait, les emplacements du type « c:\temp\ » sont à proscrire.
•	Les fichiers (log journalier et état) et les éventuels fichiers de configuration seront au format JSON. Pour permettre une lecture rapide via Notepad, il est nécessaire de mettre des retours à la ligne entre les éléments JSON. Une pagination serait un plus.
Remarque importante : si le logiciel donne satisfaction, la direction vous demandera de développer une version 2.0 utilisant une interface graphique WPF (basée sur l'architecture MVVM)


VERSION 2 :
1) Interface Graphique
Abandon du mode Console. L'application doit désormais être développée en WPF sous .Net Core
2) Nombre de travaux illimités
Le nombre de travaux de sauvegarde est désormais illimité.
3) Crypage via le logiciel CryptoSoft
Le logiciel devra être capable de crypter les fichiers en utilisant le logiciel CryptoSoft (réalisé durant le prosit 4). Seuls les fichiers dont les extensions ont été définies par l'utilisateur dans les paramètres généraux devront être cryptés.
4) Evolution du fichier Log Journalier
Le fichier Log journalier doit contenir une information supplémentaire
•	Temps nécessaire au cryptage du fichier (en ms)
o	0 : pas de cryptage
o	>0 : temps de cryptage (en ms)
o	<0 : code erreur
5) Logiciel Métier
Si la présence d'un logiciel métier est détectée, le logiciel doit interdire le lancement d'un travail de sauvegarde. Dans le cas de travaux séquentiels, le logiciel doit terminer le travail en cours et s'arrêter avant de lancer le prochain travail. L'utilisateur pourra définir le logiciel métier dans les paramètres généraux du logiciel. (Remarque : l'application calculatrice peut substituer le logiciel métier lors des démonstrations)
Remarque :
Des clients souhaitent avoir, pour chaque travail de Sauvegarde, une interface permettant d'agir sur celui-ci via trois fonctions (Play, Pause, Stop).
Le service commercial a demandé à ce que cette fonction ne soit pas prises en compte dans la version 2.0. Cependant cette fonction sera dans le cahier des charges de la version 3.0.
Vous trouverez ci-dessous le tableau de comparaison des versions


VERSION 3 :
Les évolutions demandées pour cette nouvelle version EasySave 3.0 sont :
1) Sauvegarde en parallèle
Les travaux de sauvegarde se feront en parallèle (abandon du mode séquentiel).
2) Gestion des fichiers prioritaires
Aucune sauvegarde d'un fichier non prioritaire ne peut se faire tant qu'il y a des fichiers prioritaires en attente sur au moins un travail. Sont considérés comme fichiers prioritaires, les fichiers dont les extensions sont déclarées par l'utilisateur dans une liste prédéfinie (présente dans les paramètres généraux).
3) Interdiction de transférer en simultané des fichiers de plus n Ko
Pour ne pas saturer la bande passante, il est interdit de transférer en même temps deux fichiers dont la taille est supérieure à n Ko. (n Ko paramétrable)
Rem : pendant le transfert d'un fichier de plus de n Ko, les autres travaux peuvent transférer des fichiers dont les tailles sont inférieures (sous réserve du respect de la règle des fichiers prioritaires)
4) Interaction temps réel avec chaque travail ou l'ensemble des travaux
Pour chaque travail de sauvegarde (ou l'ensemble des travaux), l'utilisateur doit pouvoir
•	Mettre sur pause (pause effective après le transfert du fichier en cours)
•	Mettre sur Play (démarrage ou reprise d'une pause)
•	Mettre sur Stop (arrêt immédiat du travail et de la tache en cours)
L'utilisateur doit pouvoir suivre en temps réel l'état d'avancement de chaque travaux (au minimum un pourcentage de progression).
5) Pause temporaire si détection du fonctionnement d'un logiciel métier
Si le logiciel détecte le fonctionnement d'un logiciel métier, il doit obligatoirement mettre en pause le transfert des fichiers
Exemple : si l'application calculatrice est lancée, toutes les taches doivent se mettre en pause.
6) Console déportée
Pour permettre de suivre en temps réel l'avancement des sauvegardes sur un poste déporté, vous devrez développer une IHM permettant à un utilisateur de suivre sur un poste distant l'évolution des travaux de sauvegarde mais aussi d'agir sur celles-ci
Les spécifications minimales de cette console sont :
• Mode de conception : WPF et FrameWork .NetCore
• Communication via des Sockets.
7) L'application devra être Mono-instance.
L'application ne peut être lancée plus d'une fois sur un même ordinateur
8) Réduction des travaux parallèles si charge réseau (option)
Si la charge réseau est supérieure à un seuil, l'application doit réduire les taches en parallèle pour ne pas saturer le réseau.

