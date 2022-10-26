Feature: Navigation tests
	As an engineer
	I want to verify the Navigation methods work
	So I can accuratelydirect the Mars Rover.

Background: 
	Given I have a new instance of the Robot Navigator class

@L1
Scenario: The Plateau is created correctly	
	When I call the GeneratePlateau method with a specific size
	Then I have a Plateau with the expected size

@L1
Scenario Outline: The new position is correct when the current direction is known
	And I have a known <knownX> coordinate and <knownY> coordinate
	And I have an expected <expectedX> coordinate and <expectedY> coordinate
	When I travel in a '<Direction>' direction
	Then The new coordinate equals the expected coordinate
		
Examples: 
	| knownX | knownY | expectedX | expectedY | Direction |
	| 5      | 5      | 5         | 6         | North     |
	| 5      | 5      | 5         | 4         | South     |
	| 5      | 5      | 6         | 5         | East      |
	| 5      | 5      | 4         | 5         | West      |