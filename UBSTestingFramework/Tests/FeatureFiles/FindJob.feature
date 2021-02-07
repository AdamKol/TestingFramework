Feature: Find Job
	In order to find job
	As a base user
	I want to navigate to jobs page

Scenario: Access homepage
	Given I have homepage url
	When I navigate to homepage url
	Then The homepage will be visible

Scenario: Access Search Jobs page
	Given I have homepage url
	When I navigate to homepage url
	Then The homepage will be visible
	When I navigate to Search Jobs page
	Then Search Jobs page will be visible

Scenario: Search for jobs
	Given I have homepage url
	When I navigate to homepage url
	Then The homepage will be visible
	When I click on search button and type 'jobs'
	Then Search Page will be visible