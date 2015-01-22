Feature: Help the user input data on our site

Background: 
Given I am on the frontpage



Scenario: I get selfexplanatory error messages when I use invalid data 
	Given I enter from: ''
	And I enter to: ''
	And I enter the date:	'30.04.15' # (today + 6 months)
	And I enter the time:	'25:12:00'
	When I search	
	Then I see the validation error: 'Skriv den station/stop/adresse, du vil rejse til'
	Then I see the validation error: 'Skriv den station/stop/adresse, du vil rejse fra'
	Then I see the validation error: 'ligger udenfor køreplanens gyldighedsperiode'
	Then I see the validation error: 'Udfyld venligts feltet "Kl.:"'


Scenario: I get selfexplanatory error messages when I use an invalid date	
	Given I enter date:	'31.04.15'
	When I search	
	Then I see the validation error	'Din indtastning "31.04.15" er ugyldig'




