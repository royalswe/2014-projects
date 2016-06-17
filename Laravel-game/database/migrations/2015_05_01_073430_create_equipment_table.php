<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateEquipmentTable extends Migration {

	/**
	 * Run the migrations.
	 *
	 * @return void
	 */
	public function up()
	{
		Schema::create('equipment', function(Blueprint $table)
		{
            $table->integer('user_id')->unsigned();
            $table->string('type', 6);
            $table->string('name', 20);
            $table->string('attribute');
            $table->string('image', 20);
            $table->unique(array('user_id', 'type'));
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
		Schema::drop('equipment');
	}

}
