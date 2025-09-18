@ContinuePurchase
Feature: Complete Purchase Flow
  As a user
  I want to complete the entire purchase process
  So that I can successfully place an order

  Scenario: Complete purchase flow with valid data
    Given I am logged in to the site for Continue Purchase
    When I add a product to the cart
    And I close the modal with "Continue Shopping"
    And I go to the cart
    And I proceed to checkout
    And I enter a message in the checkout
    And I place the order
    And I fill in the payment details
    Then I should successfully place the order
