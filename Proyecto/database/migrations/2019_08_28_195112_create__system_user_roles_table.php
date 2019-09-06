<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateSystemUserRolesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('User_Roles', function (Blueprint $table) {
            $table->string('UserId')->primary()->unique();
            $table->string('RoleId');
            $table->integer('State');
            $table->timestamps();
        });

        Schema::table('User_Roles',function($table){
            $table->foreign('UserId')->references('UserId')->on('User')->onDelete('cascade');
            $table->foreign('RoleId')->references('RoleId')->on('Roles')->onDelete('cascade');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('User_Roles');
    }
}
