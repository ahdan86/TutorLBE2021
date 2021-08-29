## F. Penambahan Kecepatan Bola

Untuk membuat game Pong ini lebih menantang, kita akan tambahkan fitur untuk menambah kecepatan bola ketika menabrak paddle dan dinding.

1. Pada folder Scripts buat script baru dengan nama `BounceSurface`.

![](./images/increasing-speed-1.png)

2. Buka script tersebut dengan kode editor anda.

3. Disini kita akan tambahkan method `void OnCollisionEnter2D()` yang menggunakan `Collision2D` sebagai parameternya. Method ini akan dipanggil secara otomatis oleh Unity ketika object dengan component ini menerima collision atau tabrakan dari object lain.

```cs
public class BounceSurface : MonoBehaviour {
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D collision) {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);
        }
    }
}
```

FYI : `OnCollisionEnter2D` hanya dapat ditrigger oleh object yang memiliki `Physics2D` yaitu object dengan tipe physics 2D, sama halnya dengan method `OnCollisionEnter` yang hanya dapat menerima `Physics` yaitu object dengan tipe physics 3D.

4. Karena tujuan kita menambahkan `OnCollisionEnter2D` adalah untuk mempercepat bola. Maka kita akan menambahkan force atau gaya pada bola tersebut saat bola tersebut menabrak dinding.

Lalu lengkapi class BounceSurface dengan script berikut ini.

```cs
public class BounceSurface : MonoBehaviour {
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D collision) {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
        }
    }
}
```

Pada code diatas kita tambahkan variable `bounceStrength` yang merupakan variable besar gaya yang akan ditambahkan ketika terjadi collision.

Kita lakukan `GetComponent<Ball>()` untuk mendapatkan component `Ball` dari benda yang menabrak dinding (bola) yang telah kita buat sebelumnya. Kemudian kita check, jika `ball` tidak null tandanya benda yang menabrak adalah bola bukan paddle atau object lainnya.

Baru kita ambil negatif gaya normal (searah dengan gaya awal) dari result collision tadi (maaf kalo ada fisika nya h3h3). Agar kita dapat menambahkan gaya ke arah pantulan bola.

![](./images/increasing-speed-4.png)

5. Setelah gaya normal didapat, selanjutnya adalah menambahkan gaya tersebut pada bola nya. Oleh karena itu kita edit pada script `Ball`. Kita tambahkan method baru yaitu `AddForce`.

```cs
public class Ball : MonoBehaviour {

    /*
        Banyak script
    */

    public void AddForce(Vector2 force)
    {
        this.rigidbody.AddForce(force);
    }
}
```

Mungkin beberapa dari kalian tau kenapa kok kita bikin fungsi `AddForce()`, padahal kan bisa semudah ambil dari `ball.rigidbody.AddForce(force)`.

Alasannya adalah biar ter-encapsulate jadi gaperlu ekspos `rigidbody` dari `Ball` melainkan bikin fungsi baru. Selengkapnya ada di kelas PBO nanti h3h3.

6. Karena telah ditambahkan fungsi `AddForce` pada ball, selanjutnya adalah tinggal manggil fungsi itu dari `BounceSurface` tadi.

```cs
public class BounceSurface : MonoBehaviour {
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D collision) {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;

            // Ini
            ball.AddForce(-normal * this.bounceStrength);
        }
    }
}
```

7. Balik ke scene, kita tambahkan component `BounceSurface` ke masing - masing object yang akan memantulkan bola (Top Wall, Bottom Wall, Player Paddle dan Computer Paddle).

Bounce Surface pada Top Wall dan Bottom Wall

![](./images/increasing-speed-7.png)

Bounce Surface pada Player Paddle dan Computer Paddle

![](./images/increasing-speed-7-1.png)

## G. Penambahan Fitur Score

Fitur score akan kita buat dengan 2 Step. Yang pertama adalah membuat class untuk mendeteksi bahwa ketika suatu paddle tidak berhasil menangkap bola maka score lawan bertambah. Selanjutnya adalah fitur reset posisi paddle ketika ada yang bertambah score.

1. Pertama buatlah script dengan nama `GameManager` pada folder `Scripts`. Dapat dilihat bahwa icon agak berbeda karena nama `GameManager` ini bawaan Unity (GameManager sering ada di pembuatan game). Nama yang lain pun sebenarnya nggak masalah.

![](./images/scoring-1.png)

2. Lengkapi script `GameManager` dengan kode berikut ini.

```cs
public class GameManager : MonoBehaviour {
    private int playerScore;
    private int computerScore;

    public void PlayerScores(){
        playerScore++;
    }

    public void ComputerScores(){
        computerScore++;
    }
}
```

Pada kode diatas, kita tambahkan `playerScore` dan `computerScore` untuk melakukan track score pada masing - masing pemain. `PlayerScores` akan dipanggil ketika computer kalah dan `ComputerScores` akan dipanggil ketika player kalah.

3. Pada script `Ball` kita tambahkan fungsi baru yaitu `ResetPosition` jadi ketika score bertambah kita akan reset posisi ball ke tengah - tengah;

```cs
public class Ball : MonoBehaviour {

    /*
        Code lain
    */

    public void ResetPosition()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = Vector2.zero;
    }
}
```

4. Pada script `Paddle` tambahkan juga fungsi `ResetPosition` untuk mereset posisi paddle ke tempat awal;

```cs
public class Paddle : MonoBehaviour {
    public void ResetPosition()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = new Vector2(rigidbody.position.x, 0.0f);
    }
}
```

5. Kembali pada `GameManager`, tambahkan variable `ball` untuk referensikan ke bola, variable `playerPaddle` dan `computerPaddle` untuk mereferensikan ke paddle masing - masing pemain pemain.

```cs
public class GameManager : MonoBehaviour {
    // Ini
    public Ball ball;

    private int playerScore;
    
    // Ini
    public Paddle playerPaddle;

    private int computerScore;
    
    // dan Ini
    public Paddle computerPaddle;

    public void PlayerScores(){
        playerScore++;
    }

    public void ComputerScores(){
        computerScore++;
    }
}
```

6. Terakhir tambahkan fungsi baru `StartRound` untuk mereset segalanya ke posisi awal.

```cs
public class GameManager : MonoBehaviour {

    public Ball ball;

    private int playerScore;
    public Paddle playerPaddle;

    private int computerScore;
    public Paddle computerPaddle;

    // Fungsi / method baru
    public void StartRound(){
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void PlayerScores(){
        playerScore++;

        // tambahkan ini
        StartRound();
    }

    public void ComputerScores(){
        computerScore++;

        // tambahkan ini
        StartRound();
    }
}
```

7. Kembali ke Scene, bikin gameObject baru dengan nama `GameManager` (boleh juga nama lain, ini biar jelas aja). Tambahkan component `GameManager` ke gameObject yang dibuat tadi. Setelah itu pasang - pasang variable nya.

![](./images/scoring-7.png)

8. Setelah semua disiapkan untuk reset dan scoring, sekarang membuat sistem trigger penambahan score nya. Buat script baru dengan nama `ScoringZone`. Script ini mirip dengan script `BounceSurface` yang telah kita buat.

```cs
using UnityEngine;
using UnityEngine.Events;

public class ScoringZone : MonoBehaviour
{
    public UnityEvent scoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null) {
            this.scoreTrigger.Invoke();
        }
    }

}
```

Script diatas kita menggunakan fitur bawaan Unity yaitu `UnityEvent`. Jadi kita bisa mengatur fungsi / method apa yang akan terjadi ketika event tersebut dipanggil / di-invoke melalui Unity.

Script diatas pada dasarnya check collision dari bola, ketika yang ber-collision adalah bola maka Invoke event `scoreTrigger`.

9. Kembali ke Scene, pada gameObject `Left Wall` dan `Right Wall`tambahkan component `ScoringZone`. Pada `Left Wall` drag gameObject `GameMaster` ke field lalu pilih fungsi `ComputerScores`. Ini artinya ketika bola menabrak `Left Wall` maka Player Kalah, sehingga fungsi `ComputerScores` akan dipanggil untuk menambah score computer.

![](./images/scoring-9.png)

Lakukan hal yang sama tapi berkebalikan pada `Right Wall`.

![](./images/scoring-9-1.png)

10. Untuk testing bisa tambahkan `Debug.Log(score)` pada script `GameManager` lalu test play.

## H. Penambahan UI

Agar Pemain bisa tahu score game nya, maka kita akan tambahkan UI score masing - masing pemain menggunakan fitur UI pada Unity.

1. Buat lah gameObject `Canvas`. 

![](./images/ui-1.png)

2. Pada gameObject `Canvas` edit konfigurasi componentnya sebagai berikut.

![](./images/ui-3.png)

3. Lalu pada `Canvas` tambahkan `Text` lalu beri nama `Player Score`.

Note : `Text` hanya dapat bekerja kalo ada di canvas, jadi pastikan bikin gameObject `Text` dengan cara klik kanan `Canvas` lalu `UI > Text`.

![](./images/ui-2.png)

4. Kita perlu edit beberapa konfigurasi dari UI Text nya menjadi seperti ini.

![](./images/ui-3-1.png)

Pada gambar diatas kita ubah anchor nya (yang gambar kotak) menjadi diatas tengah. Lalu Pos X, Pos Y. Tambahkan text "0" agar lebih jelas untuk melihat posisi UI nya. Ubah Font menjadi `bit5x3` dari asset yang disediakan dan ubah Font size menjadi 128. Lalu terakhir ubah alignment nya.

5. Buat gameObject `Text` lagi dari canvas juga, kali ini ubah namanya menjadi `Computer Score`. Lakukan hal yang sama seperti `Player Score`.

![](./images/ui-5.png)

6. Kurang lebih tampilan UI akan seperti berikut ini.

![](./images/ui-6.png)

7. Pada script `GameManager` tambahkan variable `playerScoreText` dan `computerScoreText`. Namun sebelum itu, tambahkan namespace `UnityEngine.UI` karena kita akan menggunakan class `Text` yang ada pada namespace tersebut.

```cs
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*
        Variable yang lainnya..
    */

    public Text playerScoreText;
    public Text computerScoreText;
}
```

8. Setelah itu tambahkan fungsi baru untuk melakukan set player dan computer score pada `GameManager`.

```cs
private void SetPlayerScore(int score)
{
    playerScore = score;
    playerScoreText.text = score.ToString();
}

private void SetComputerScore(int score)
{
    computerScore = score;
    computerScoreText.text = score.ToString();
}
```

`playerScoreText.text` merupakan property `text` pada UI `Player Score`. Sama halnya dengan `Computer Score`. Kita akan lakukan update text ini setiap penambahan score terjadi.

9. Karena kita telah menambahkan kedua fungsi diatas, kita perlu modifikasi fungsi `PlayerScores` dan `ComputerScores` agar tidak redundant.

```cs
public void PlayerScores(){
    // ubah dari..
    // playerScore++;
    // menjadi..
    SetPlayerScore(playerScore + 1);

    StartRound();
}

public void ComputerScores(){
    // ubah dari..
    // computerScore++;
    // menjadi..
    SetComputerScore(computerScore + 1);

    StartRound();
}
```

10. Terakhir, kita pasang - pasang variable nya pada `GameManager` lalu coba mainkan gamenya.

![](./images/ui-10.png)

## I. Fitur Retry Game

Pada step ini kita akan tambahkan fitur retry game ketika Player menekan tombol `R`.

1. Pada `GameManager` buat fungsi baru dengan nama `NewGame`. Lalu isi dengan code berikut.

```cs
public void NewGame()
{
    SetPlayerScore(0);
    SetComputerScore(0);
    StartRound();
}
```

Dapat dilihat bahwa pada dasarnya `NewGame` mereset score player dan computer menjadi 0, lalu mereset posisi paddle dan bola ke posisi awal.

2. Lalu pada tambahkan juga `Update` kalo belum ada, kalo sudah ada kita modifikasi aja.

```cs
private void Update()
{
    if (Input.GetKeyDown(KeyCode.R)) {
        NewGame();
    }
}
```

`Input` merupakan static class untuk melakukan pengecheck-an input. Pada code diatas maksudnya adalah, ketika tombol `R` di tekan sekali maka akan bernilai `true` sehingga block `NewGame` akan di-eksekusi.

3. Coba mainkan game dan tekan tombol `R`. Kalo berhasil maka score game akan tereset dan posisi kembali ke posisi semula.

## J. Yay, nice

Selamat game Pong telah berhasil dibuat.