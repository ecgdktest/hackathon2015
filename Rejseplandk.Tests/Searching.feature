Feature: Searching
Background: 
	Given I am on the frontpage

Scenario: I can search for a journey
	Given I enter from: 'Delta Park 40, 2665 Vallensbæk Strand, Vallensbæk Komm'
	And I enter to: 'Axel Kiers Vej 11, 8270 Højbjerg, Århus Kommune'
	When I Search
	Then I get at least 3 travelplan


@UI	
Scenario: I can see the searchbar on all pages 
	Then I see the Searchbar

	Given I enter from: 'Tønder Busstation'
	And I enter to: 'Aarhus H'

	Then I see search results

	When I expand the Searchbar section
	Then I see the Searchbar

	When I enter the time:	'25:12:00'
	And I Search
	Then I get at least 3 travelplan







