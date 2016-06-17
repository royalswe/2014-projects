<?php

$factory('App\User', [
	'username' => $faker->name,
	'email' => $faker->email,
	'password' => bcrypt('password')
]);

?>