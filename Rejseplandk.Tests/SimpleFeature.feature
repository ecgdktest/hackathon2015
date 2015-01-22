Feature: Rejseplanen

Scenario: I can search for a journey
	Given I enter from: 'Delta Park 40, 2665 Vallensbæk Strand, Vallensbæk Komm'
	And I enter to: 'Axel Kiers Vej 11, 8270 Højbjerg, Århus Kommune'
	When I Search
	Then I get at least 3 travelplan