<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class ObservacionesMensajero extends Model
{
     protected $table = 'observaciones_mensajero';
     protected $guarded = ['id'];
     public $timestamps = false;

     public function observaciones()
     {
         return $this->hasMany('App\ObservacionEntrega', 'observacion', 'id');
     }
}
