<?php

use Laracasts\Integrated\Extensions\Laravel as IntegrationTest;
use Laracasts\Integrated\Services\Laravel\DatabaseTransactions;
use Laracasts\TestDummy\Factory as TestDummy;

class AuthTest extends TestCase {

	use DatabaseTransactions; // Rolles back test

	/** @test */

	function Register_a_new_user_and_check_database_columns()
	{
		$credentials = ['email' => 'foobar@example.com'];
        $statsCredentials = ['damage' => 10, 'health' => 100, 'gold' => 100, 'luck' => 4, 'xp' => 0, 'raid' => 1];

		$this->register($credentials)
			->verifyInDatabase('users', $credentials)
            ->verifyInDatabase('stats', $statsCredentials)
			->andSeePageIs('/');
	}

	/** @test */
	function Check_if_username_and_email_is_taken()
	{
		// create temporary username and email
		$this->createUser($overrides = ['username' => 'example', 'email' => 'example@example.com']);

		// We shouldn't be able to sign up with existing username and email
		$this->register($overrides)
			->andSee('The email has already been taken.')
			->andSee('The username has already been taken.')
			->onPage('auth/register');
	}

	protected function createUser(array $overrides = [])
	{
		return TestDummy::create('App\User', $overrides);
	}


	protected function register(array $overrides)
	{
		$fields = $this->getRegisterFields($overrides);

		return $this->visit('auth/register')
			->andSubmitForm('Register', $fields);
	}

	protected function getRegisterFields(array $overrides)
	{
		$user = TestDummy::attributesFor('App\User', $overrides);
		return $user + ['password_confirmation' => $user['password']];
	}

}
