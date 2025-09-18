@AddToCart
Feature: Add Product to Cart
  As a user
  I want to add products to the cart
  So that I can proceed with my purchase

  Scenario: Add a product to the cart successfully
    Given I am logged in to the site for Add to Cart
    When I go to the products page
    And I click on "View Product" of a specific product
    And I click on "Add to cart"
    Then I should see the "Added!" modal
    And I close the modal
