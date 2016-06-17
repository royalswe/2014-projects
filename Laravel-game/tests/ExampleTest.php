<?php

use Laracasts\Integrated\Extensions\Laravel as IntegrationTest;
use Laracasts\TestDummy\Factory as TestDummy;

class ExampleTest extends TestCase {

	/**
	 * A basic functional test example.
	 *
	 * @return void
	 */
	public function testBasicExample()
	{
		$this->visit('auth/login');
	}

}
