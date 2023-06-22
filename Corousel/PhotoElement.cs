using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PhotoElement : MonoBehaviour
{
    // public string thumb_filename;
    // public string big_filename;
    //
    // [SerializeField] private RawImage img;
    // [SerializeField] private AspectRatioFitter aspectFitter;
    // [SerializeField] public GameObject descPanel;
    // [SerializeField] public TMPro.TextMeshProUGUI descText;
    // [SerializeField] private RectTransform bookModeDump;
    // [SerializeField] private TMPro.TextMeshProUGUI bookDescText;
    // [SerializeField] private Material blur;
    // [SerializeField] private Image blurPanel;
    // [SerializeField] private Image desc_blurPanel;
    //
    // [SerializeField] GameObject translationPanel;
    // [SerializeField] RectTransform togglesContainer;
    // [SerializeField] GameObject[] translationBlocks; 
    // Toggle[] toggles;
    //
    // private Texture2D tex;
    // private bool can_get = true;
    // private Material inst_blur;
    // private float radius_blur = 0;
    // public event System.Action<PhotoElement> OnClick;
    //
    // private void Start()
    // {
    //     var btn = GetComponent<Button>();
    //     if(btn != null)
    //     {
    //         btn.onClick.AddListener(OpenGalleryView);
    //     }
    // }
    //
    // void OpenGalleryView()
    // {
    //     if (BaseScreen.Instance is HomeScreen hs)
    //     {
    //         hs.ShowPhotoGallery(new FileInfo(big_filename).Directory.FullName, "", transform.GetSiblingIndex());
    //     }
    //     OnClick?.Invoke(this);
    // }
    //
    // public void Init(string _thumb_filename, string _big_filename)
    // {
    //     if (File.Exists(_thumb_filename))
    //         thumb_filename = _thumb_filename;
    //     else
    //         thumb_filename = _big_filename;
    //     if (File.Exists(_big_filename))
    //         big_filename = _big_filename;
    //     else
    //         big_filename = thumb_filename;
    //     if (!File.Exists(thumb_filename))
    //     {
    //         can_get = false;
    //         Debug.LogError($"Cant get files: {thumb_filename}");
    //     }
    //     var rtr_elem = GetComponent<RectTransform>();
    //     var galleryContainer = rtr_elem.parent as RectTransform;
    //     var sz = rtr_elem.sizeDelta;
    //     float k = sz.x / sz.y;
    //     sz.y = galleryContainer.rect.height;
    //     sz.x = k * galleryContainer.rect.height;
    //     rtr_elem.sizeDelta = sz;
    //     if (descPanel != null)
    //     {
    //         string descFilename = big_filename.BeforeLast(".") + "_desc.txt";
    //         if (File.Exists(descFilename))
    //         {
    //             descPanel.SetActive(true);
    //             descText.text = File.ReadAllText(descFilename);
    //             //LayoutRebuilder.ForceRebuildLayoutImmediate(descText.rectTransform);
    //             var rtr = GetComponent<RectTransform>();
    //             sz = rtr.sizeDelta;
    //             var rtr_desc = descPanel.GetComponent<RectTransform>();
    //             sz.y -= rtr_desc.rect.height;
    //             rtr.sizeDelta = sz;
    //             var d = rtr_desc.rect.height / rtr.rect.height;
    //             var pivot = rtr.pivot;
    //             pivot.y -= d / 2f;
    //             rtr.pivot = pivot;
    //         }
    //         else if(bookDescText != null)
    //         {
    //             descFilename = big_filename.BeforeLast(".") + ".txt";
    //             if(File.Exists(descFilename))
    //             {
    //                 bookDescText.gameObject.SetActive(true);
    //                 bookDescText.text = File.ReadAllText(descFilename);
    //             }
    //             else
    //             {
    //                 // translation
    //                 descFilename = big_filename.BeforeLast(".") + "_tr.txt";
    //                 if (File.Exists(descFilename))
    //                 {
    //                     if (togglesContainer != null)
    //                     {
    //                         toggles = togglesContainer.GetComponentsInChildren<Toggle>(true);
    //                         for (int i = 0; i < toggles.Length; i++)
    //                         {
    //                             int n = i;
    //                             toggles[i].onValueChanged.AddListener((val) =>
    //                             {
    //                                 translationBlocks[n].SetActive(val);
    //                             });
    //                         }
    //                         translationPanel.SetActive(true);
    //                         var text = File.ReadAllText(descFilename);
    //                         while (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
    //                         {
    //                             string num_str = text.After("<").Before(">");
    //                             if (string.IsNullOrEmpty(num_str.Trim(' '))) break;
    //                             int index = num_str.ToInt();
    //                             toggles[index].gameObject.SetActive(true);
    //                             translationBlocks[index].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = text.After(">").Before("<").TrimStart('\n', '\r').TrimEnd('\n', '\r');
    //                             text = "<" + text.After(">").After("<");
    //                         }
    //                     }
    //                 }
    //             }
    //         }
    //     }
    // }
    //
    // public void Set(bool thumb)
    // {
    //     if (!can_get) return;
    //     if (tex == null) tex = new Texture2D(1, 1);
    //     tex.LoadImage(File.ReadAllBytes(thumb ? thumb_filename : big_filename));
    //     tex.Apply();
    //     if (thumb)
    //     {
    //         img.texture = tex;
    //         if (blur != null)
    //         {
    //             inst_blur = Instantiate(blur);
    //             inst_blur.SetFloat("_Radius", 0);
    //             blurPanel.material = inst_blur;
    //             desc_blurPanel.material = inst_blur;
    //         }
    //         aspectFitter.aspectRatio = tex.width / (float)tex.height;
    //         //if (bookDescText != null && bookDescText.gameObject.activeSelf)
    //         //{
    //         //    var rtr = bookModeDump.parent as RectTransform;
    //         //    bookModeDump.sizeDelta = new Vector2(rtr.rect.width / 2, bookModeDump.sizeDelta.y);
    //         //}
    //     }
    //     else
    //     {
    //         FloatingPicture.Show(big_filename, tex);
    //     }
    // }
    //
    // public void LerpBlur(float to_val, float t)
    // {
    //     if (inst_blur == null) return;
    //     radius_blur = Mathf.Lerp(radius_blur, to_val, t);
    //     inst_blur.SetFloat("_Radius", radius_blur);
    // }
    //
    // private void OnDestroy()
    // {
    //     if(tex != null)
    //         DestroyImmediate(tex);
    // }
}
