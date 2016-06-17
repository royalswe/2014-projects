<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateStatsTable extends Migration {

	/**
	 * Run the migrations.
	 *
	 * @return void
	 */
	public function up()
	{
		Schema::create('stats', function(Blueprint $table)
		{
			//$table->increments('id');
            $table->integer('user_id')->unsigned() ->unique();
			$table->integer('damage')->default(10);
			$table->integer('health')->default(100);
            $table->integer('gold')->default(100);
            $table->integer('luck')->default(4);
            $table->integer('xp')->default(0);
            $table->integer('raid')->default(1);
			$table->timestamps();

            $table->foreign('user_id')
                ->references('id')
                ->on('users')
                ->unique()
                ->onDelete('cascade');
		});
	}

	/**
	 * Reverse the migrations.
	 *
	 * @return void
	 */
	public function down()
	{
		Schema::drop('stats');
	}

}
