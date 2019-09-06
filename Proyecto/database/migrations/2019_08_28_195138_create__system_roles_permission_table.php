<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateSystemRolesPermissionTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('Roles_Permission', function (Blueprint $table) {
            $table->string('RoleId');
            $table->string('PermissionId');
            $table->integer('State');
            $table->timestamps();
        });

        Schema::table('Roles_Permission',function($table){
            $table->foreign('RoleId')->references('RoleId')->on('Roles')->onDelete('cascade');
            $table->foreign('PermissionId')->references('PermissionId')->on('Permission')->onDelete('cascade');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('Roles_Permission');
    }
}
