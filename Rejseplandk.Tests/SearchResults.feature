Feature: Results

@UI	
Scenario: I see the searchbar on our pages 
	Then I see the Searchbar

	Given I enter from: 'Tønder Busstation'
	And I enter to: 'Aarhus H'

	Then I see search results

	When I expand the Searchbar section
	Then I see the Searchbar

	When I enter the time:	'25:12:00'
	And I Search
	Then I get at least 3 travelplan



