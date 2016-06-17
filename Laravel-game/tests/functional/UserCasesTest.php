<?php


use Laracasts\Integrated\Extensions\Laravel as IntegrationTest;
use Laracasts\Integrated\Services\Laravel\DatabaseTransactions;
use Laracasts\TestDummy\Factory as TestDummy;



class UserCasesTest extends TestCase {

    use DatabaseTransactions; // Rolles back test

    /** @test */

    public function Check_if_user_can_upgrade_character_and_saves_in_database()
    {
        $statsCredentials = ['damage' => 11, 'health' => 101, 'luck' => 5, 'gold' => 36];

        $this->loggedInUser()
            ->click('Character')
            ->andSeePageIs('user')
            ->andSee('Gold: 100')
            ->click('Damage:')
            ->click('Luck:')
            ->click('Health:')
            ->verifyInDatabase('stats', $statsCredentials)
            ->click('Health:')
            ->andSee('Not enough gold');
    }

    /** @test */

    public function Check_if_user_can_shop_and_saves_in_database()
    {
        $equipmentCredentials = ['type' => 'Weapon', 'name' => 'Sword', 'attribute' => 4, 'image' => 'kidsSword.png'];

        $this->loggedInUser()
            ->click('Shop')
            ->andSeePageIs('shop')
            ->click('Buy: 3 gold')
            ->andSee('You bought Iron Hoe')
            ->click('Buy: 5 gold')
            ->andSee('You bought Wooden Shield')
            ->click('Buy: 2 gold')
            ->andSee('You bought Thors Snake Charm')
            ->click('Buy: 9 gold')
            ->andSee('You bought Sword')
            ->click('Buy: 9 gold')
            ->andSee('You already have that equipment')
            ->verifyInDatabase('equipment', $equipmentCredentials);
    }

    /** @test */

    public function Logout_user()
    {
        $this->loggedInUser()
            ->click('Logout')
            ->andSeePageIs('auth/login');
    }

    /** @test */

    public function Check_authentication_on_all_pages()
    {
        $this->visit('user')
            ->andSeePageIs('auth/login')
            ->visit('shop')
            ->andSeePageIs('auth/login')
            ->visit('arena')
            ->andSeePageIs('auth/login')
            ->visit('raid')
            ->andSeePageIs('auth/login')
            ->visit('townhall')
            ->andSeePageIs('auth/login');
    }


}
