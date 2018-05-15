<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class ObservacionEntrega extends Model
{
     protected $table = 'observaciones_entrega';
     protected $guarded = ['id'];
     public $timestamps = false;

     public function observacion()
     {
         return $this->belongsTo('App\ObservacionesMensajero', 'observacion', 'id');
     }

     public function tracking()
     {
         return $this->belongsTo('App\TrackingMensajeria', 'tracking', 'id');
     }
}
