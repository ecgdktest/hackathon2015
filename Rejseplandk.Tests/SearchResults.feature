Feature: Results

@UI	
Scenario: I can see the travel details 
	Given I enter from: 'Djurs'
	And I enter to: 'Aarhus H'

	Then I get at least 3 travelplan



