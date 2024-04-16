### CLASES/OBJETOS INVOLUCRADOS EN EL PROYECTO.

- User:
  - UserID.
  - Username.
  - Email.
  - Password. 

- Sound:
  - SoundID.
  - UserID.
  - SoundName.
  - SoundDescription.
  - File.
  - UploadDate.
  - Labels.
  - IsPremium.
  - Price.

- UserDownloads.
  - DownloadID.
  - SoundID.
  - UserID.
  - DownloadDate.

- UserPurchases.
  - PurchaseID.
  - UserID.
  - SoundID.
  - PurchaseDate.
  - SoundPrice.
  - PaymentStatus.
  - PaymentMethod.

- UserSounds.
  - UserSoundID.
  - UserID.
  - SoundID.
  - PurchaseID.