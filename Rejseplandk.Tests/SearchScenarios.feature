Feature: SearchScenarios

@mytag
Scenario Outline: Add two numbers
	Given I am on the frontpage
	And I fill search: '<from>' and '<to>'
	And I pick a date '<Dato>'
	And I choose traveltype '<TravelType>'
	And I pick return '<Travel>'
	When I Search
	Then I get at least 3 travelplan
	And take a screenshoot
Examples: 
| To         | From       | Dato    | TravelType | Travel |
| POI        | Telefon nr | Fremtid | Ankomst    | Enkelt |
| POI        | POI        | I dag   | Afgang     | Retur  |
| Telefon nr | POI        | Fremtid | Afgang     | Enkelt |
| Street     | Street     | Fremtid | Ankomst    | Retur  |
| Street     | Telefon nr | I dag   | Afgang     | Enkelt |
| Station    | POI        | I dag   | Ankomst    | Enkelt |
| Telefon nr | Street     | I dag   | Afgang     | Enkelt |
| Telefon nr | Station    | I dag   | Ankomst    | Retur  |
| Telefon nr | Telefon nr | I dag   | Ankomst    | Retur  |
| Station    | Station    | Fremtid | Afgang     | Enkelt |
| Station    | Street     | Fremtid | Ankomst    | Retur  |
| Street     | POI        | I dag   | Ankomst    | Enkelt |
| POI        | Station    | I dag   | Afgang     | Retur  |
| Street     | Station    | I dag   | Afgang     | Enkelt |
| POI        | Street     | I dag   | Afgang     | Retur  |
| Station    | Telefon nr | I dag   | Ankomst    | Retur  |

